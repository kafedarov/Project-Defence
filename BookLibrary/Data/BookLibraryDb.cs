using BookLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class BookLibraryDb : IdentityDbContext<AppUser>
    {
        public BookLibraryDb(DbContextOptions<BookLibraryDb> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Contactus> contactus { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
            .HasOne(b => b.Genre)         // Each Book has one Genre
            .WithMany(g => g.Books)       // Each Genre can have many Books
            .HasForeignKey(b => b.GenreId); // Foreign key property in Book


            //Seeded Genres
            builder.Entity<Genre>().HasData(

                new Genre { Id = 1, Name = "Sci-Fi" },
                new Genre { Id = 2, Name = "Horror" },
                new Genre { Id = 3, Name = "True Crime" },
                new Genre { Id = 5, Name = "Fantasy" },
                new Genre { Id = 6, Name = "Action & Adventure" },
                new Genre { Id = 7, Name = "Historical Fiction" },
                new Genre { Id = 8, Name = "Romance" },
                new Genre { Id = 9, Name = "Graphic Novel" },
                new Genre { Id = 10, Name = "Autobiography" },
                new Genre { Id = 11, Name = "Biography" },
                new Genre { Id = 12, Name = "History" },
                new Genre { Id = 13, Name = "Religion" },
                new Genre { Id = 14, Name = "Self-Help" },
                new Genre { Id = 15, Name = "How-To/Guide" }

                );
            
            //Seeded Books
            builder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Red Rising", Author = "Pierce Brown", Publisher = "Del Rey", ImagePath = "RedRising.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 1 ,Price=100},
                new Book { Id = 2, Title = "Pet Sematary", Author = "Stephen King", Publisher = "Gallery", ImagePath = "PetSematary.jpg", DateAdded = new DateTime(2023, 11, 2), GenreId = 2,Price=800 },
                new Book { Id = 3, Title = "Dune", Author = "Frank Herbert", Publisher = "Ace", ImagePath = "dune.jpg", DateAdded = new DateTime(2023, 11, 3), GenreId = 1,Price=901 },
                new Book { Id = 4, Title = "HTML & CSS: Design and Build Websites", Author = "Jon Duckett", Publisher = "Wiley", ImagePath = "HtmlCss.jpg", DateAdded = new DateTime(2023, 10, 28), GenreId = 2,Price=78 },
                new Book { Id = 5, Title = "Python Crash Course: A Hands On, Project-Based Introduction to Programming", Author = "Eric Matthes", Publisher = "No Starch Press", ImagePath = "PythonCrashCourse.jpg", DateAdded = new DateTime(2023, 10, 27), GenreId =3,Price=72 },
               new Book { Id = 6, Title = "The Devil In the White City: Murder, Magic, and Madness at the Fair That Changed America", Author = "Erik Larson", Publisher = "Vintage", ImagePath = "DevilWhiteCity.jpg", DateAdded = new DateTime(2023, 12, 1), GenreId = 3,Price=56 },
               new Book { Id = 8, Title = "Golden Son", Author = "Pierce Brown", Publisher = "Del Rey", ImagePath = "GoldenSon.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 1,Price=55 },
               new Book { Id = 9, Title = "Morning Star", Author = "Pierce Brown", Publisher = "Del Rey", ImagePath = "MorningSon.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 3 ,Price=73},


				 new Book { Id = 10, Title = "The Princess while save you", Author = "Shara Henric", Publisher = "Vintage", ImagePath = "aa-jacket-medium.jpg", DateAdded = new DateTime(2023, 12, 1), GenreId = 6,Price=40 },
				new Book { Id = 11, Title = "MATTHEW QUIRK", Author = "Joe Brown", Publisher = "Del Rey", ImagePath = "aa-matthew.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 6,Price=79 },
				new Book { Id = 12, Title = "TWO STORM WOOD", Author = "Pierce Brown", Publisher = "Del Rey", ImagePath = "aa-twostorm.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 6,Price=45},

				new Book { Id = 13, Title = "THE CITY OF BRASS", Author = "Shara Henric", Publisher = "Vintage", ImagePath = "F1_BOOK.jpg", DateAdded = new DateTime(2023, 12, 1), GenreId = 5,Price=99 },
				new Book { Id = 14, Title = "NIGHT CIRCUS", Author = "Pierce Brown", Publisher = "Del Rey", ImagePath = "F2_BOOK.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 5,Price=100 },
				new Book { Id = 15, Title = "KAZUO ISHIGURO", Author = "Stephen King", Publisher = "Del Rey", ImagePath = "F3_BOOK.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 5,Price=120 },

				new Book { Id = 16, Title = "THE CITY OF BRASS", Author = "JACKIE AND MARIA", Publisher = "Vintage", ImagePath = "H1_BOOK.jpg", DateAdded = new DateTime(2023, 12, 1), GenreId = 7 ,Price=102},
				new Book { Id = 17, Title = "NIGHT CIRCUS", Author = "DUST CHILD", Publisher = "Del Rey", ImagePath = "H2_BOOK.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 7,Price=48 },
				new Book { Id = 18, Title = "KAZUO ISHIGURO", Author = "PAM JENOFF", Publisher = "Del Rey", ImagePath = "H3_BOOK.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 7,Price=90 },

				new Book { Id = 19, Title = "ALL THE WHITE SPACES", Author = "JACKIE AND MARIA", Publisher = "Vintage", ImagePath = "HO1_BOOK.jpg", DateAdded = new DateTime(2023, 12, 1), GenreId = 2,Price=67 },
				new Book { Id = 20, Title = "THOMAS OLDE HEUVELT", Author = "DUST CHILD", Publisher = "Del Rey", ImagePath = "HO2_BOOK.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 2,Price=56 },
				new Book { Id = 21, Title = "HIDDEN PICTURES", Author = "PAM JENOFF", Publisher = "Del Rey", ImagePath = "HO3_BOOK.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 2,Price=53 },

				new Book { Id = 22, Title = "LIVING & DYING IN AMERICA", Author = "JACKIE AND MARIA", Publisher = "Vintage", ImagePath = "HO1_BOOK.jpg", DateAdded = new DateTime(2023, 12, 1), GenreId =9,Price=55 },
				new Book { Id = 23, Title = "DUCKS", Author = "DUST CHILD", Publisher = "Del Rey", ImagePath = "HO2_BOOK.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 9,Price=99 },
				new Book { Id = 24, Title = "CURLFRRIENDS NEW IN TOWN", Author = "PAM JENOFF", Publisher = "Del Rey", ImagePath = "HO3_BOOK.jpg", DateAdded = new DateTime(2023, 11, 29), GenreId = 9,Price=88 }


				);

            // *****************Users
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "admin",
                Id = "2",
                ConcurrencyStamp = "2"
            });
           

            //create user
            var appUser = new AppUser
            {
                Id = "2",
                Email = "admin@abc.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Ofoedu",
                UserName = "admin@abc.com",

                NormalizedUserName = "admin@abc.com"
            };

            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Abc.123456");
            builder.Entity<AppUser>().HasData(appUser);
            // User 2
            var appUser1 = new AppUser
            {
                Id = "1",
                Email = "user@abc.com",
                EmailConfirmed = true,
                FirstName = "user",
                LastName = "Ofoedu",
                UserName = "user@abc.com",

                NormalizedUserName = "user@abc.com"
            };

            //set user password
            PasswordHasher<AppUser> ph1 = new PasswordHasher<AppUser>();
            appUser1.PasswordHash = ph1.HashPassword(appUser1, "Abc.123456");
            builder.Entity<AppUser>().HasData(appUser1);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "2"
            });


            base.OnModelCreating(builder);
        }


        //These two methods are for recording and saving the Date and Time a Book was created.
        public override Task<int> SaveChangesAsync(bool acceptChangesOnSuccess, CancellationToken cancelToken = default)
        {
            UpdateDateAdded();
            return base.SaveChangesAsync(acceptChangesOnSuccess, cancelToken);
        }

        private void UpdateDateAdded()
        {
            var books = ChangeTracker.Entries()
                 .Where(e => e.State == EntityState.Added && e.Entity is Book)
                 .Select(e => e.Entity as Book);

            foreach (var book in books)
            {
                book.DateAdded = DateTime.UtcNow;
            }
        }
    }
}
