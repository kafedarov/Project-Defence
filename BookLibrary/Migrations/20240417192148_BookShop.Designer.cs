﻿// <auto-generated />
using System;
using BookLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookShop.Migrations
{
    [DbContext(typeof(BookLibraryDb))]
    [Migration("20240417192148_BookShop")]
    partial class BookShop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookLibrary.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9f9d5f99-1edb-4e5c-ae07-9d3cdbcd78af",
                            Email = "admin@abc.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "Ofoedu",
                            LockoutEnabled = false,
                            NormalizedUserName = "admin@abc.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEH0yUNL66VPcuURF/zj0pb/w8ZYT3+6aepH13r0wYzEBM3S8EC8TEO4ZAzk+uc7xog==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7e3701a4-5b27-4c84-88cb-dcfec76eba0d",
                            TwoFactorEnabled = false,
                            UserName = "admin@abc.com"
                        },
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "01edcf16-14f1-47b6-82b8-a28372f46e20",
                            Email = "user@abc.com",
                            EmailConfirmed = true,
                            FirstName = "user",
                            LastName = "Ofoedu",
                            LockoutEnabled = false,
                            NormalizedUserName = "user@abc.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEPNrayx3+RFo99qEopWMp+WgF6m5ejqK8YK84n8+f0bblQrvzwOz0abRvjsuFYcKVg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "95678224-d54a-4c48-b4a9-e86afcd6707a",
                            TwoFactorEnabled = false,
                            UserName = "user@abc.com"
                        });
                });

            modelBuilder.Entity("BookLibrary.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Pierce Brown",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 1,
                            ImagePath = "RedRising.jpg",
                            Price = 100,
                            Publisher = "Del Rey",
                            Title = "Red Rising"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Stephen King",
                            DateAdded = new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            ImagePath = "PetSematary.jpg",
                            Price = 800,
                            Publisher = "Gallery",
                            Title = "Pet Sematary"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Frank Herbert",
                            DateAdded = new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 1,
                            ImagePath = "dune.jpg",
                            Price = 901,
                            Publisher = "Ace",
                            Title = "Dune"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Jon Duckett",
                            DateAdded = new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            ImagePath = "HtmlCss.jpg",
                            Price = 78,
                            Publisher = "Wiley",
                            Title = "HTML & CSS: Design and Build Websites"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Eric Matthes",
                            DateAdded = new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 3,
                            ImagePath = "PythonCrashCourse.jpg",
                            Price = 72,
                            Publisher = "No Starch Press",
                            Title = "Python Crash Course: A Hands On, Project-Based Introduction to Programming"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Erik Larson",
                            DateAdded = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 3,
                            ImagePath = "DevilWhiteCity.jpg",
                            Price = 56,
                            Publisher = "Vintage",
                            Title = "The Devil In the White City: Murder, Magic, and Madness at the Fair That Changed America"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Pierce Brown",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 1,
                            ImagePath = "GoldenSon.jpg",
                            Price = 55,
                            Publisher = "Del Rey",
                            Title = "Golden Son"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Pierce Brown",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 3,
                            ImagePath = "MorningSon.jpg",
                            Price = 73,
                            Publisher = "Del Rey",
                            Title = "Morning Star"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Shara Henric",
                            DateAdded = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 6,
                            ImagePath = "aa-jacket-medium.jpg",
                            Price = 40,
                            Publisher = "Vintage",
                            Title = "The Princess while save you"
                        },
                        new
                        {
                            Id = 11,
                            Author = "Joe Brown",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 6,
                            ImagePath = "aa-matthew.jpg",
                            Price = 79,
                            Publisher = "Del Rey",
                            Title = "MATTHEW QUIRK"
                        },
                        new
                        {
                            Id = 12,
                            Author = "Pierce Brown",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 6,
                            ImagePath = "aa-twostorm.jpg",
                            Price = 45,
                            Publisher = "Del Rey",
                            Title = "TWO STORM WOOD"
                        },
                        new
                        {
                            Id = 13,
                            Author = "Shara Henric",
                            DateAdded = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 5,
                            ImagePath = "F1_BOOK.jpg",
                            Price = 99,
                            Publisher = "Vintage",
                            Title = "THE CITY OF BRASS"
                        },
                        new
                        {
                            Id = 14,
                            Author = "Pierce Brown",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 5,
                            ImagePath = "F2_BOOK.jpg",
                            Price = 100,
                            Publisher = "Del Rey",
                            Title = "NIGHT CIRCUS"
                        },
                        new
                        {
                            Id = 15,
                            Author = "Stephen King",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 5,
                            ImagePath = "F3_BOOK.jpg",
                            Price = 120,
                            Publisher = "Del Rey",
                            Title = "KAZUO ISHIGURO"
                        },
                        new
                        {
                            Id = 16,
                            Author = "JACKIE AND MARIA",
                            DateAdded = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 7,
                            ImagePath = "H1_BOOK.jpg",
                            Price = 102,
                            Publisher = "Vintage",
                            Title = "THE CITY OF BRASS"
                        },
                        new
                        {
                            Id = 17,
                            Author = "DUST CHILD",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 7,
                            ImagePath = "H2_BOOK.jpg",
                            Price = 48,
                            Publisher = "Del Rey",
                            Title = "NIGHT CIRCUS"
                        },
                        new
                        {
                            Id = 18,
                            Author = "PAM JENOFF",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 7,
                            ImagePath = "H3_BOOK.jpg",
                            Price = 90,
                            Publisher = "Del Rey",
                            Title = "KAZUO ISHIGURO"
                        },
                        new
                        {
                            Id = 19,
                            Author = "JACKIE AND MARIA",
                            DateAdded = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            ImagePath = "HO1_BOOK.jpg",
                            Price = 67,
                            Publisher = "Vintage",
                            Title = "ALL THE WHITE SPACES"
                        },
                        new
                        {
                            Id = 20,
                            Author = "DUST CHILD",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            ImagePath = "HO2_BOOK.jpg",
                            Price = 56,
                            Publisher = "Del Rey",
                            Title = "THOMAS OLDE HEUVELT"
                        },
                        new
                        {
                            Id = 21,
                            Author = "PAM JENOFF",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            ImagePath = "HO3_BOOK.jpg",
                            Price = 53,
                            Publisher = "Del Rey",
                            Title = "HIDDEN PICTURES"
                        },
                        new
                        {
                            Id = 22,
                            Author = "JACKIE AND MARIA",
                            DateAdded = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 9,
                            ImagePath = "HO1_BOOK.jpg",
                            Price = 55,
                            Publisher = "Vintage",
                            Title = "LIVING & DYING IN AMERICA"
                        },
                        new
                        {
                            Id = 23,
                            Author = "DUST CHILD",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 9,
                            ImagePath = "HO2_BOOK.jpg",
                            Price = 99,
                            Publisher = "Del Rey",
                            Title = "DUCKS"
                        },
                        new
                        {
                            Id = 24,
                            Author = "PAM JENOFF",
                            DateAdded = new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 9,
                            ImagePath = "HO3_BOOK.jpg",
                            Price = 88,
                            Publisher = "Del Rey",
                            Title = "CURLFRRIENDS NEW IN TOWN"
                        });
                });

            modelBuilder.Entity("BookLibrary.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("BookLibrary.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BookLibrary.Models.Contactus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("contactus");
                });

            modelBuilder.Entity("BookLibrary.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 3,
                            Name = "True Crime"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Action & Adventure"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Historical Fiction"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Graphic Novel"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Autobiography"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Biography"
                        },
                        new
                        {
                            Id = 12,
                            Name = "History"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Religion"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Self-Help"
                        },
                        new
                        {
                            Id = 15,
                            Name = "How-To/Guide"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "2",
                            Name = "admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "2",
                            RoleId = "2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BookLibrary.Models.Book", b =>
                {
                    b.HasOne("BookLibrary.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookLibrary.Models.Cart", b =>
                {
                    b.HasOne("BookLibrary.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BookLibrary.Models.CartItem", b =>
                {
                    b.HasOne("BookLibrary.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookLibrary.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BookLibrary.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BookLibrary.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookLibrary.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BookLibrary.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookLibrary.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("BookLibrary.Models.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
