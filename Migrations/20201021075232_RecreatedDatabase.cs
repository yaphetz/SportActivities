using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportActivities.Migrations
{
    public partial class RecreatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Choices",
                columns: table => new
                {
                    ChoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(nullable: false),
                    FirstActivityId = table.Column<int>(nullable: true),
                    DefaultActivityId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.ChoiceId);
                    table.ForeignKey(
                        name: "FK_Choices_Activities_DefaultActivityId",
                        column: x => x.DefaultActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Choices_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Choices_Activities_FirstActivityId",
                        column: x => x.FirstActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Name", "Status" },
                values: new object[,]
                {
                    { 7, "Tenis", null },
                    { 8, "Ping Pong", null },
                    { 1, "7Card", true },
                    { 2, "Belaqva", true },
                    { 3, "Paradisul Acvatic", true },
                    { 4, "Parc Aventura", true },
                    { 5, "Inot", false },
                    { 6, "Bowling", false }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4280b6a-0653-4cbd-a0p6-f1701e926e73", "120c15b9-b72f-4cd6-b315-f99f292b39cb", "admin", "ADMIN" },
                    { "c9280b6a-0613-4cbd-a9e6-f1701e926e73", "bfcfd474-993d-4f80-84bd-cf5bb9b07dbb", "basic", "BASIC" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, "7c46b9ba-754e-4396-a750-1bcee5e3a216", "admin@admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEGL1E/zBpsTBuqPp7wUs3phIPEi+8Mc27qo9GGhHgRkY774Mj1L2xjsP3ek9r74rsw==", null, false, "60a206da-de02-4c8e-ae0c-2c2185cb9605", false, "admin@admin.com" },
                    { "b4280b6a-0613-4ciod-a9e6-f1702f926e73", 0, "89bf9b6e-8450-46d3-a636-e78706cf46cc", "basic@basic.com", true, "Basic", "Basic", false, null, "BASIC@BASIC.COM", "BASIC@BASIC.COM", "AQAAAAEAACcQAAAAEB2Tgv8BXgwTeIDjN/y/Q0YEbX7txI6gvF+x7JdTwjpb1+ziO7v96qagX/Piyl3otg==", null, false, "132efc1a-1a58-4060-b304-c2d8f6ddd6d0", false, "basic@basic.com" },
                    { "b4280b6a-0613-4cbd-ae6-f1701e926e73", 0, "e3e543ab-5236-4bbb-949c-fbcf915e9756", "a.popescu@peoplepower.ro", true, "Andrei", "Popescu", false, null, "A.POPESCU@PEOPLEPOWER.RO", "A.POPESCU@PEOPLEPOWER.RO", "AQAAAAEAACcQAAAAEHfzbb9mrm654fsFlKhG35iu8pd1SUuEgjpOdUQO9z7PJcjhcddxe8YuKxWqEXjCmw==", null, false, "59dc0375-6455-496b-b583-04b74fbcd034", false, "a.popescu@peoplepower.ro" },
                    { "g4280b6a-0613-4awod-a9e6-f1702f926e73", 0, "90cdddca-3c7d-4212-aa1c-13fb72013e83", "m.gheorghe@peoplepower.ro", true, "Maria", "Gheorghe", false, null, "M.GHEORGHE@PEOPLEPOWER.RO", "M.GHEORGHE@PEOPLEPOWER.RO", "AQAAAAEAACcQAAAAEGC3sIIY6EkuWC0XmbU3Ph+rV0xbdhcTqYUzpuUVMcxwnE4XO78YlTtldITkRjocQw==", null, false, "1e201592-9388-4e0e-b099-799ff1eaf63a", false, "m.gheorghe@peoplepower.ro" },
                    { "5t280b6a-0613-4awod-a9e6-f1702f926e73", 0, "9b94f045-a58a-4458-833c-8d81052d7a71", "i.stanescu@peoplepower.ro", true, "Ionut", "Stanescu", false, null, "I.STANESCU@PEOPLEPOWER.RO", "I.STANESCU@PEOPLEPOWER.RO", "AQAAAAEAACcQAAAAEAZzcish5FGN6LEUPhPRUAgmjhscV1mczkLSeUYf/Q425YrwO3/GWUtBKlk+Itqbiw==", null, false, "ad393d34-4307-4c04-b3f1-28804f1950cc", false, "i.stanescu@peoplepower.ro" },
                    { "acd80b6a-0613-4awod-a9e6-f1702f926e73", 0, "7f97614e-ca7f-48e3-8693-c752dabd551f", "m.istrate@peoplepower.ro", true, "Mircea", "Istrate", false, null, "M.ISTRATE@PEOPLEPOWER.RO", "M.ISTRATE@PEOPLEPOWER.RO", "AQAAAAEAACcQAAAAEALD2Dtxf5IfAzWER6EZQ4kvmw+tFo2tVLWGP3wSPQJ7lWpftzpTkOTveIo7tGV8+g==", null, false, "9cfbfaa0-1167-4062-8afc-c09a7245b4d5", false, "m.istrate@peoplepower.ro" },
                    { "bhd80b6a-0613-6awod-a9e6-f1702f926e73", 0, "9a101ec8-a62a-4755-8a75-2ba3bf821e29", "m.eremia@peoplepower.ro", true, "Marian", "Eremia", false, null, "M.EREMIA@PEOPLEPOWER.RO", "M.EREMIA@PEOPLEPOWER.RO", "AQAAAAEAACcQAAAAEDT83rmCY1OPJkw8pXRi747BbKxxTooU/xvf9pLKO5Z/XPMgZoOdbichLCXZJfYL7g==", null, false, "a80e500b-5de3-45c2-8651-0c4a139d08c1", false, "m.eremia@peoplepower.ro" },
                    { "9cd80b6a-0613-8awod-a9e6-f1702f926e73", 0, "9449877a-ccc5-41a5-8b69-c09c874cc1d2", "i.pop@peoplepower.ro", true, "Ilinca", "Pop", false, null, "I.POP@PEOPLEPOWER.RO", "I.POP@PEOPLEPOWER.RO", "AQAAAAEAACcQAAAAEOmyw1+XTComReasOFQeyM8KDIQvxWkEKihhyNwDmBUVk3B2Cs12EO5Cv7f0GClqjQ==", null, false, "f1c94940-1bb0-4f0d-8e31-460fb6ab5742", false, "i.pop@peoplepower.ro" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "a4280b6a-0653-4cbd-a0p6-f1701e926e73" },
                    { "b4280b6a-0613-4ciod-a9e6-f1702f926e73", "c9280b6a-0613-4cbd-a9e6-f1701e926e73" },
                    { "b4280b6a-0613-4cbd-ae6-f1701e926e73", "c9280b6a-0613-4cbd-a9e6-f1701e926e73" },
                    { "g4280b6a-0613-4awod-a9e6-f1702f926e73", "c9280b6a-0613-4cbd-a9e6-f1701e926e73" },
                    { "5t280b6a-0613-4awod-a9e6-f1702f926e73", "c9280b6a-0613-4cbd-a9e6-f1701e926e73" },
                    { "acd80b6a-0613-4awod-a9e6-f1702f926e73", "c9280b6a-0613-4cbd-a9e6-f1701e926e73" },
                    { "bhd80b6a-0613-6awod-a9e6-f1702f926e73", "c9280b6a-0613-4cbd-a9e6-f1701e926e73" },
                    { "9cd80b6a-0613-8awod-a9e6-f1702f926e73", "c9280b6a-0613-4cbd-a9e6-f1701e926e73" }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "ChoiceId", "Date", "DefaultActivityId", "EmployeeId", "FirstActivityId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "b4280b6a-0613-4cbd-ae6-f1701e926e73", 7 },
                    { 2, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "g4280b6a-0613-4awod-a9e6-f1702f926e73", 6 },
                    { 3, new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "5t280b6a-0613-4awod-a9e6-f1702f926e73", 5 },
                    { 4, new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "acd80b6a-0613-4awod-a9e6-f1702f926e73", null },
                    { 5, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "bhd80b6a-0613-6awod-a9e6-f1702f926e73", 4 },
                    { 6, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "9cd80b6a-0613-8awod-a9e6-f1702f926e73", 7 }
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
                name: "IX_Choices_DefaultActivityId",
                table: "Choices",
                column: "DefaultActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_EmployeeId",
                table: "Choices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_FirstActivityId",
                table: "Choices",
                column: "FirstActivityId");
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
                name: "Choices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
