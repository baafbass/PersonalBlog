using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Data.Migrations
{
    public partial class ForNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admin",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 484, DateTimeKind.Local).AddTicks(6835), new DateTime(2023, 5, 2, 17, 59, 36, 484, DateTimeKind.Local).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 472, DateTimeKind.Local).AddTicks(685), new DateTime(2023, 5, 2, 17, 59, 36, 472, DateTimeKind.Local).AddTicks(719) });

            migrationBuilder.UpdateData(
                table: "ContactInfo",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 392, DateTimeKind.Local).AddTicks(7057), new DateTime(2023, 5, 2, 17, 59, 36, 392, DateTimeKind.Local).AddTicks(7095) });

            migrationBuilder.UpdateData(
                table: "ContactMe",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 425, DateTimeKind.Local).AddTicks(3178), new DateTime(2023, 5, 2, 17, 59, 36, 425, DateTimeKind.Local).AddTicks(3209) });

            migrationBuilder.UpdateData(
                table: "Education",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 382, DateTimeKind.Local).AddTicks(3821), new DateTime(2023, 5, 2, 17, 59, 36, 382, DateTimeKind.Local).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 372, DateTimeKind.Local).AddTicks(3758), new DateTime(2023, 5, 2, 17, 59, 36, 372, DateTimeKind.Local).AddTicks(3793) });

            migrationBuilder.UpdateData(
                table: "Hobbies",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 361, DateTimeKind.Local).AddTicks(1384), new DateTime(2023, 5, 2, 17, 59, 36, 361, DateTimeKind.Local).AddTicks(1418) });

            migrationBuilder.UpdateData(
                table: "Hobbies",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 361, DateTimeKind.Local).AddTicks(2872), new DateTime(2023, 5, 2, 17, 59, 36, 361, DateTimeKind.Local).AddTicks(2877) });

            migrationBuilder.UpdateData(
                table: "Hobbies",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 361, DateTimeKind.Local).AddTicks(2891), new DateTime(2023, 5, 2, 17, 59, 36, 361, DateTimeKind.Local).AddTicks(2895) });

            migrationBuilder.UpdateData(
                table: "HomePageSliders",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 353, DateTimeKind.Local).AddTicks(7602), new DateTime(2023, 5, 2, 17, 59, 36, 353, DateTimeKind.Local).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "Site",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 344, DateTimeKind.Local).AddTicks(7455), new DateTime(2023, 5, 2, 17, 59, 36, 344, DateTimeKind.Local).AddTicks(7490) });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 332, DateTimeKind.Local).AddTicks(9196), new DateTime(2023, 5, 2, 17, 59, 36, 332, DateTimeKind.Local).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 325, DateTimeKind.Local).AddTicks(6265), new DateTime(2023, 5, 2, 17, 59, 36, 325, DateTimeKind.Local).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 326, DateTimeKind.Local).AddTicks(414), new DateTime(2023, 5, 2, 17, 59, 36, 326, DateTimeKind.Local).AddTicks(419) });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 326, DateTimeKind.Local).AddTicks(437), new DateTime(2023, 5, 2, 17, 59, 36, 326, DateTimeKind.Local).AddTicks(441) });

            migrationBuilder.UpdateData(
                table: "Summary",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 5, 2, 17, 59, 36, 311, DateTimeKind.Local).AddTicks(7490), new DateTime(2023, 5, 2, 17, 59, 36, 311, DateTimeKind.Local).AddTicks(8742) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Admin",
                newName: "Password");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 859, DateTimeKind.Local).AddTicks(6564), new DateTime(2023, 3, 21, 20, 32, 59, 859, DateTimeKind.Local).AddTicks(6599) });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 848, DateTimeKind.Local).AddTicks(9551), new DateTime(2023, 3, 21, 20, 32, 59, 848, DateTimeKind.Local).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "ContactInfo",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 784, DateTimeKind.Local).AddTicks(3057), new DateTime(2023, 3, 21, 20, 32, 59, 784, DateTimeKind.Local).AddTicks(3097) });

            migrationBuilder.UpdateData(
                table: "ContactMe",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 811, DateTimeKind.Local).AddTicks(5572), new DateTime(2023, 3, 21, 20, 32, 59, 811, DateTimeKind.Local).AddTicks(5614) });

            migrationBuilder.UpdateData(
                table: "Education",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 775, DateTimeKind.Local).AddTicks(7873), new DateTime(2023, 3, 21, 20, 32, 59, 775, DateTimeKind.Local).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 766, DateTimeKind.Local).AddTicks(681), new DateTime(2023, 3, 21, 20, 32, 59, 766, DateTimeKind.Local).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "Hobbies",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(2316), new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(2359) });

            migrationBuilder.UpdateData(
                table: "Hobbies",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(3961), new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(3966) });

            migrationBuilder.UpdateData(
                table: "Hobbies",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(3981), new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "HomePageSliders",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 750, DateTimeKind.Local).AddTicks(6444), new DateTime(2023, 3, 21, 20, 32, 59, 750, DateTimeKind.Local).AddTicks(6695) });

            migrationBuilder.UpdateData(
                table: "Site",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 742, DateTimeKind.Local).AddTicks(810), new DateTime(2023, 3, 21, 20, 32, 59, 742, DateTimeKind.Local).AddTicks(848) });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 732, DateTimeKind.Local).AddTicks(3470), new DateTime(2023, 3, 21, 20, 32, 59, 732, DateTimeKind.Local).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 723, DateTimeKind.Local).AddTicks(9165), new DateTime(2023, 3, 21, 20, 32, 59, 723, DateTimeKind.Local).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 724, DateTimeKind.Local).AddTicks(2463), new DateTime(2023, 3, 21, 20, 32, 59, 724, DateTimeKind.Local).AddTicks(2468) });

            migrationBuilder.UpdateData(
                table: "SocialMedias",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 724, DateTimeKind.Local).AddTicks(2485), new DateTime(2023, 3, 21, 20, 32, 59, 724, DateTimeKind.Local).AddTicks(2489) });

            migrationBuilder.UpdateData(
                table: "Summary",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedTime", "ModifiedTime" },
                values: new object[] { new DateTime(2023, 3, 21, 20, 32, 59, 710, DateTimeKind.Local).AddTicks(2625), new DateTime(2023, 3, 21, 20, 32, 59, 710, DateTimeKind.Local).AddTicks(4109) });
        }
    }
}
