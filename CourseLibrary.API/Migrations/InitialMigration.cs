using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ContactsLibrary.API.Migrations
{
	public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Level = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactsSkills",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts_Skills", x => new { ContactId = x.ContactId, SkillId = x.SkillId, });
                    table.ForeignKey(
                        name: "FK_Contacts_ContactsSkills_Id",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_ContactsSkills_Id",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "FirstName", "LastName", "Email", "Address", "Mobile" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Berry", "Griffin", "bery.griffin@gmail.com", "First Street No 12 Milano Italy", "0745616789" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Nancy", "Rye", "nancy.rye@gmail.com", "Second Street No 1 Milano Italy", "0745616789" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Eli", "Bones", "eli.bones@gmail.com", "Third Street No 12 Rome Italy", "0745616789" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "Arnold", "Stafford", "arnold.stanford@gmail.com", "Third Street No 15 Rome Italy", "0745616789" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Linda", "Well", "linda.well@gmail.com", "Third Street No 15 Barcelona Spain", "0745616789" },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), "Ruthe", "Cloven", "ruthe.cloven@gmail.com", "Third Street No 16 Barcelona Spain", "0745616789" },
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), "Amy", "Ridley", "amy.ridley@ygmail.com", "Fall Street No 72 Switzerland", "0745616789" },
                    { new Guid("71838f8b-6ab3-4539-9e67-4e77b8ede1c0"), "Morris", "Lessmore", "morris.lessmore@gmail.com", "Fall Street No 72 Switzerland", "0745616789" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Level", "Name" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), 0, "Beginner" },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), 1, "Intermediate" },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), 2, "Advanced" },
                });

            migrationBuilder.InsertData(
                table: "ContactsSkills",
                columns: new[] { "ContactId", "SkillId" },
                values: new object[,]
                {
                   { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b") },
                   { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee") },
                   { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97") },
                   { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b") },
                   { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97") },
                   { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97") },
                   { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97") },
                   { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee") },
                   { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee") },
                   { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97") },
                   { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee") },
                   { new Guid("71838f8b-6ab3-4539-9e67-4e77b8ede1c0"), new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactsSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
