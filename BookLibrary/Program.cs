using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Data;
using BookLibrary.Models;
using BookLibrary.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BookLibraryDBConnection");


builder.Services.AddDbContext<BookLibraryDb>(options =>
{
	options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
});

//Tells .Net that we will use the BookLibraryDb for users to LogIn
//builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<BookLibraryDb>();

builder.Services.AddIdentity<AppUser, IdentityRole>()
	.AddDefaultTokenProviders()
	.AddDefaultUI()
	.AddEntityFrameworkStores<BookLibraryDb>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IBookList, BookList>();
builder.Services.AddSingleton<IGenreList, GenreList>();
builder.Services.AddScoped<ICartService, CartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{
    app.UseExceptionHandler("/Home/Error");
    // Handle specific status codes with re-execution to custom paths
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
