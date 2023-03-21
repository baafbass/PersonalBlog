using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutMe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    profilPicture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Job = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobIcon = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CV = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutMe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SecurityQuestions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SQAnswers = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CategoryImg = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactMe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    educationTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    School = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GradePointAverage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    experienceTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    jobPosition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hobbies = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HomePageSliders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ShortContent = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageSliders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    siteName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    siteKeywords = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LogoTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MediaLogo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MediaURL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Summary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summary", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutMe",
                columns: new[] { "ID", "Birthday", "CV", "CreatedByName", "CreatedTime", "FirstName", "IsActive", "IsDeleted", "Job", "JobIcon", "LastName", "ModifiedByName", "ModifiedTime", "profilPicture" },
                values: new object[] { 1, "31.08.2001", "", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 859, DateTimeKind.Local).AddTicks(6564), "Abdoul Faride", false, false, "Software Developer", "<i class=\"fa - solid fa - laptop - code\"></i>", "Bassirou Alzouma", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 859, DateTimeKind.Local).AddTicks(6599), "" });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "ID", "CreatedByName", "CreatedTime", "Email", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedTime", "Password", "SQAnswers", "SecurityQuestions" },
                values: new object[] { 1, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 848, DateTimeKind.Local).AddTicks(9551), "abdoulfaridbassirou7898@gmai.com", false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 848, DateTimeKind.Local).AddTicks(9592), "3a799ade3169bd0d5da32652a3a888c5", "a453e0ac9f56a805e5249ffdf7d04847", "What is your father name" });

            migrationBuilder.InsertData(
                table: "ContactInfo",
                columns: new[] { "ID", "Adress", "City", "CreatedByName", "CreatedTime", "Email", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedTime", "phoneNumber" },
                values: new object[] { 1, "Arif Nihat Asya Erkek Öğrenci Yurdu", "Sakarya/Serdiven", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 784, DateTimeKind.Local).AddTicks(3057), "abdoulfaridbassirou7898@gmail.com", false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 784, DateTimeKind.Local).AddTicks(3097), "+905315058891" });

            migrationBuilder.InsertData(
                table: "ContactMe",
                columns: new[] { "ID", "CreatedByName", "CreatedTime", "EmailAdress", "FirstName", "IsActive", "IsDeleted", "LastName", "Message", "ModifiedByName", "ModifiedTime", "Subject" },
                values: new object[] { 1, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 811, DateTimeKind.Local).AddTicks(5572), "abdoulfaridbassirou7898@gmail.com", "Abdoul Faride", false, false, "Bassirou Alzouma", "I will become a high value man and rich", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 811, DateTimeKind.Local).AddTicks(5614), "Business" });

            migrationBuilder.InsertData(
                table: "Education",
                columns: new[] { "ID", "CreatedByName", "CreatedTime", "Description", "Duration", "GradePointAverage", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedTime", "School", "educationTitle" },
                values: new object[] { 1, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 775, DateTimeKind.Local).AddTicks(7873), "We are learning programming and a litle of business", "Oct.2021-Today", "3.19/4", false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 775, DateTimeKind.Local).AddTicks(7909), "University Of Sakarya", "License-Information System Engineering" });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "ID", "CreatedByName", "CreatedTime", "Description", "Duration", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedTime", "experienceTitle", "jobPosition" },
                values: new object[] { 1, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 766, DateTimeKind.Local).AddTicks(681), "Hardening System-Gone Phishing-Protection of keys-Analyze and Recommendations", "February", false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 766, DateTimeKind.Local).AddTicks(722), "Cybersecurity Virtual Internship", "Cyber Security Analyst" });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "ID", "CreatedByName", "CreatedTime", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedTime", "hobbies" },
                values: new object[,]
                {
                    { 1, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(2316), false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(2359), "Learning new technologies" },
                    { 2, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(3961), false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(3966), "Playing Football" },
                    { 3, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(3981), false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 757, DateTimeKind.Local).AddTicks(3985), "Reading books" }
                });

            migrationBuilder.InsertData(
                table: "HomePageSliders",
                columns: new[] { "ID", "Content", "CreatedByName", "CreatedTime", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedTime", "ShortContent", "Title" },
                values: new object[] { 1, "", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 750, DateTimeKind.Local).AddTicks(6444), false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 750, DateTimeKind.Local).AddTicks(6695), "My name is Abdoul Faride Bassirou Alzouma. I am from Niger and I am 21 years old. After graduating from high school, I had the chance to pursue my educational adventure in Turkey, where I am currently studying Information System Engineering at Sakarya University. I am very interested in science and technology, and I also have the ability to speak five different languages: English, French, Turkish, Hausa, and Zarma.", "Software Developer" });

            migrationBuilder.InsertData(
                table: "Site",
                columns: new[] { "ID", "CreatedByName", "CreatedTime", "Description", "IsActive", "IsDeleted", "Logo", "LogoTitle", "ModifiedByName", "ModifiedTime", "siteKeywords", "siteName" },
                values: new object[] { 1, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 742, DateTimeKind.Local).AddTicks(810), "Abdoul Faride Bassirou Alzouma Software Developer", false, false, "<i class=\"fa - solid fa - display - code\"></i>", "Farid Bass", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 742, DateTimeKind.Local).AddTicks(848), "C#,.NET,WEB,SOFTWARE", "BAAF" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "ID", "CreatedByName", "CreatedTime", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedTime", "Percentage", "SkillName" },
                values: new object[] { 1, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 732, DateTimeKind.Local).AddTicks(3470), false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 732, DateTimeKind.Local).AddTicks(3510), 90, "C#" });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "ID", "CreatedByName", "CreatedTime", "IsActive", "IsDeleted", "MediaLogo", "MediaName", "MediaURL", "ModifiedByName", "ModifiedTime" },
                values: new object[,]
                {
                    { 1, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 723, DateTimeKind.Local).AddTicks(9165), false, false, "<i class=\"fa - brands fa - facebook\"></i>", "Facebook", "https://www.facebook.com/baaf.baaf.7", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 723, DateTimeKind.Local).AddTicks(9203) },
                    { 2, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 724, DateTimeKind.Local).AddTicks(2463), false, false, "<i class=\"fa - brands fa - linkedin\"></i>", "LinkedIn", "https://www.linkedin.com/in/abdoul-faride-bassirou-alzouma-a61b321bb/", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 724, DateTimeKind.Local).AddTicks(2468) },
                    { 3, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 724, DateTimeKind.Local).AddTicks(2485), false, false, "<i class=\"fa - brands fa - instagram\"></i>", "Instagram", "https://www.instagram.com/farid_bass_alz/", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 724, DateTimeKind.Local).AddTicks(2489) }
                });

            migrationBuilder.InsertData(
                table: "Summary",
                columns: new[] { "ID", "Content", "CreatedByName", "CreatedTime", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedTime" },
                values: new object[] { 1, "Welcome to my blog! I am a second-year Information System Engineering student who is passionate about software development. Currently, I am working on improving my skills in C# and .Net technologies by building projects. I also have experience with HTML, CSS, and JavaScript and have completed many projects using C and C++ languages. As a big fan of cybersecurity, I am very attentive to security during the software development process.", "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 710, DateTimeKind.Local).AddTicks(2625), false, false, "InitialCreated", new DateTime(2023, 3, 21, 20, 32, 59, 710, DateTimeKind.Local).AddTicks(4109) });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutMe");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.DropTable(
                name: "ContactMe");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "HomePageSliders");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "Summary");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
