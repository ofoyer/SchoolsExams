using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolExams.Migrations
{
    public partial class UpdateQuestionaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionaries_Subjects_SubjectIDid",
                table: "Questionaries");

            migrationBuilder.DropIndex(
                name: "IX_Questionaries_SubjectIDid",
                table: "Questionaries");

            migrationBuilder.DropColumn(
                name: "SubjectIDid",
                table: "Questionaries");

            migrationBuilder.AddColumn<int>(
                name: "Subjectid",
                table: "Questionaries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questionaries_Subjectid",
                table: "Questionaries",
                column: "Subjectid");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionaries_Subjects_Subjectid",
                table: "Questionaries",
                column: "Subjectid",
                principalTable: "Subjects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionaries_Subjects_Subjectid",
                table: "Questionaries");

            migrationBuilder.DropIndex(
                name: "IX_Questionaries_Subjectid",
                table: "Questionaries");

            migrationBuilder.DropColumn(
                name: "Subjectid",
                table: "Questionaries");

            migrationBuilder.AddColumn<int>(
                name: "SubjectIDid",
                table: "Questionaries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questionaries_SubjectIDid",
                table: "Questionaries",
                column: "SubjectIDid");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionaries_Subjects_SubjectIDid",
                table: "Questionaries",
                column: "SubjectIDid",
                principalTable: "Subjects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
