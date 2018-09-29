using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalResume.Migrations
{
    public partial class j : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    WebAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "education",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    applicantID = table.Column<int>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    degreeType = table.Column<string>(nullable: true),
                    gradDate = table.Column<string>(nullable: true),
                    institution = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education", x => x.ID);
                    table.ForeignKey(
                        name: "FK_education_applicant_applicantID",
                        column: x => x.applicantID,
                        principalTable: "applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "experience",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    applicantID = table.Column<int>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    endDate = table.Column<string>(nullable: true),
                    placeWorked = table.Column<string>(nullable: true),
                    startDate = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experience", x => x.ID);
                    table.ForeignKey(
                        name: "FK_experience_applicant_applicantID",
                        column: x => x.applicantID,
                        principalTable: "applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "references",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    applicantID = table.Column<int>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    companyName = table.Column<string>(nullable: true),
                    emailAddress = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    mailingAddress = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_references", x => x.ID);
                    table.ForeignKey(
                        name: "FK_references_applicant_applicantID",
                        column: x => x.applicantID,
                        principalTable: "applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    applicantID = table.Column<int>(nullable: true),
                    experienceLevel = table.Column<string>(nullable: true),
                    skillName = table.Column<string>(nullable: true),
                    yearsUsed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_skills_applicant_applicantID",
                        column: x => x.applicantID,
                        principalTable: "applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "duties",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    applicantID = table.Column<int>(nullable: true),
                    experienceID = table.Column<int>(nullable: true),
                    summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_duties_applicant_applicantID",
                        column: x => x.applicantID,
                        principalTable: "applicant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_duties_experience_experienceID",
                        column: x => x.experienceID,
                        principalTable: "experience",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_duties_applicantID",
                table: "duties",
                column: "applicantID");

            migrationBuilder.CreateIndex(
                name: "IX_duties_experienceID",
                table: "duties",
                column: "experienceID");

            migrationBuilder.CreateIndex(
                name: "IX_education_applicantID",
                table: "education",
                column: "applicantID");

            migrationBuilder.CreateIndex(
                name: "IX_experience_applicantID",
                table: "experience",
                column: "applicantID");

            migrationBuilder.CreateIndex(
                name: "IX_references_applicantID",
                table: "references",
                column: "applicantID");

            migrationBuilder.CreateIndex(
                name: "IX_skills_applicantID",
                table: "skills",
                column: "applicantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "duties");

            migrationBuilder.DropTable(
                name: "education");

            migrationBuilder.DropTable(
                name: "references");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "experience");

            migrationBuilder.DropTable(
                name: "applicant");
        }
    }
}
