﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Migrations
{
    public partial class BookShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contactus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "2", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "01edcf16-14f1-47b6-82b8-a28372f46e20", "user@abc.com", true, "user", "Ofoedu", false, null, null, "user@abc.com", "AQAAAAEAACcQAAAAEPNrayx3+RFo99qEopWMp+WgF6m5ejqK8YK84n8+f0bblQrvzwOz0abRvjsuFYcKVg==", null, false, "95678224-d54a-4c48-b4a9-e86afcd6707a", false, "user@abc.com" },
                    { "2", 0, "9f9d5f99-1edb-4e5c-ae07-9d3cdbcd78af", "admin@abc.com", true, "Admin", "Ofoedu", false, null, null, "admin@abc.com", "AQAAAAEAACcQAAAAEH0yUNL66VPcuURF/zj0pb/w8ZYT3+6aepH13r0wYzEBM3S8EC8TEO4ZAzk+uc7xog==", null, false, "7e3701a4-5b27-4c84-88cb-dcfec76eba0d", false, "admin@abc.com" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sci-Fi" },
                    { 2, "Horror" },
                    { 3, "True Crime" },
                    { 5, "Fantasy" },
                    { 6, "Action & Adventure" },
                    { 7, "Historical Fiction" },
                    { 8, "Romance" },
                    { 9, "Graphic Novel" },
                    { 10, "Autobiography" },
                    { 11, "Biography" },
                    { 12, "History" },
                    { 13, "Religion" },
                    { 14, "Self-Help" },
                    { 15, "How-To/Guide" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "2" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "DateAdded", "GenreId", "ImagePath", "Price", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Pierce Brown", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "RedRising.jpg", 100, "Del Rey", "Red Rising" },
                    { 2, "Stephen King", new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "PetSematary.jpg", 800, "Gallery", "Pet Sematary" },
                    { 3, "Frank Herbert", new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "dune.jpg", 901, "Ace", "Dune" },
                    { 4, "Jon Duckett", new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "HtmlCss.jpg", 78, "Wiley", "HTML & CSS: Design and Build Websites" },
                    { 5, "Eric Matthes", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "PythonCrashCourse.jpg", 72, "No Starch Press", "Python Crash Course: A Hands On, Project-Based Introduction to Programming" },
                    { 6, "Erik Larson", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "DevilWhiteCity.jpg", 56, "Vintage", "The Devil In the White City: Murder, Magic, and Madness at the Fair That Changed America" },
                    { 8, "Pierce Brown", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "GoldenSon.jpg", 55, "Del Rey", "Golden Son" },
                    { 9, "Pierce Brown", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "MorningSon.jpg", 73, "Del Rey", "Morning Star" },
                    { 10, "Shara Henric", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "aa-jacket-medium.jpg", 40, "Vintage", "The Princess while save you" },
                    { 11, "Joe Brown", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "aa-matthew.jpg", 79, "Del Rey", "MATTHEW QUIRK" },
                    { 12, "Pierce Brown", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "aa-twostorm.jpg", 45, "Del Rey", "TWO STORM WOOD" },
                    { 13, "Shara Henric", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "F1_BOOK.jpg", 99, "Vintage", "THE CITY OF BRASS" },
                    { 14, "Pierce Brown", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "F2_BOOK.jpg", 100, "Del Rey", "NIGHT CIRCUS" },
                    { 15, "Stephen King", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "F3_BOOK.jpg", 120, "Del Rey", "KAZUO ISHIGURO" },
                    { 16, "JACKIE AND MARIA", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "H1_BOOK.jpg", 102, "Vintage", "THE CITY OF BRASS" },
                    { 17, "DUST CHILD", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "H2_BOOK.jpg", 48, "Del Rey", "NIGHT CIRCUS" },
                    { 18, "PAM JENOFF", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "H3_BOOK.jpg", 90, "Del Rey", "KAZUO ISHIGURO" },
                    { 19, "JACKIE AND MARIA", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "HO1_BOOK.jpg", 67, "Vintage", "ALL THE WHITE SPACES" },
                    { 20, "DUST CHILD", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "HO2_BOOK.jpg", 56, "Del Rey", "THOMAS OLDE HEUVELT" },
                    { 21, "PAM JENOFF", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "HO3_BOOK.jpg", 53, "Del Rey", "HIDDEN PICTURES" },
                    { 22, "JACKIE AND MARIA", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "HO1_BOOK.jpg", 55, "Vintage", "LIVING & DYING IN AMERICA" },
                    { 23, "DUST CHILD", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "HO2_BOOK.jpg", 99, "Del Rey", "DUCKS" },
                    { 24, "PAM JENOFF", new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "HO3_BOOK.jpg", 88, "Del Rey", "CURLFRRIENDS NEW IN TOWN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AppUserId",
                table: "Carts",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "contactus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
