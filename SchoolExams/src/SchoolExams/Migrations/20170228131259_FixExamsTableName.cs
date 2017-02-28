using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolExams.Migrations
{
    public partial class FixExamsTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Questionaries_Questionaryid",
                table: "Exam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exam",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Questionaries_Questionaryid",
                table: "Exam",
                column: "Questionaryid",
                principalTable: "Questionaries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Exam_Questionaryid",
                table: "Exam",
                newName: "IX_Exams_Questionaryid");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Questionaries_Questionaryid",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exams",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Questionaries_Questionaryid",
                table: "Exams",
                column: "Questionaryid",
                principalTable: "Questionaries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Exams_Questionaryid",
                table: "Exams",
                newName: "IX_Exam_Questionaryid");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");
        }
    }
}
