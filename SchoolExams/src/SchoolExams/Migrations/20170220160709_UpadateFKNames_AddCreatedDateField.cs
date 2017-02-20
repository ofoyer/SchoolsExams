using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolExams.Migrations
{
    public partial class UpadateFKNames_AddCreatedDateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Questionaries_QuestnaryIDid",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_QuestnaryIDid",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "QuestnaryIDid",
                table: "Exam");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Questionaries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Exam",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Questionaryid",
                table: "Exam",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Questionaryid",
                table: "Exam",
                column: "Questionaryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Questionaries_Questionaryid",
                table: "Exam",
                column: "Questionaryid",
                principalTable: "Questionaries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Questionaries_Questionaryid",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_Questionaryid",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Questionaries");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "Questionaryid",
                table: "Exam");

            migrationBuilder.AddColumn<int>(
                name: "QuestnaryIDid",
                table: "Exam",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_QuestnaryIDid",
                table: "Exam",
                column: "QuestnaryIDid");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Questionaries_QuestnaryIDid",
                table: "Exam",
                column: "QuestnaryIDid",
                principalTable: "Questionaries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
