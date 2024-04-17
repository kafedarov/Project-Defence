using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Migrations
{
    public partial class addmigrationBookShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "157ad2f1-3db0-47c5-ba7f-1468e8840acf", "AQAAAAEAACcQAAAAEMNdrXZuEjTSSwD9CY5INzmIMDnfs0K4HF4VbdRi029tPTqacGE4mgdhHVbE2Tsw6A==", "893f7d92-829a-43fb-b3a6-67b88832abf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c229f30e-2fc0-48ab-aa25-c55857b23915", "AQAAAAEAACcQAAAAEIELNVZNBZSN4ah9ZfxMGbbnau1ID8iwG25uDEs0OM0m7kwvM4g5B/Zk3+IDJcNcRg==", "80305a0e-40b2-4feb-a84e-2c4e8df04d98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01edcf16-14f1-47b6-82b8-a28372f46e20", "AQAAAAEAACcQAAAAEPNrayx3+RFo99qEopWMp+WgF6m5ejqK8YK84n8+f0bblQrvzwOz0abRvjsuFYcKVg==", "95678224-d54a-4c48-b4a9-e86afcd6707a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f9d5f99-1edb-4e5c-ae07-9d3cdbcd78af", "AQAAAAEAACcQAAAAEH0yUNL66VPcuURF/zj0pb/w8ZYT3+6aepH13r0wYzEBM3S8EC8TEO4ZAzk+uc7xog==", "7e3701a4-5b27-4c84-88cb-dcfec76eba0d" });
        }
    }
}
