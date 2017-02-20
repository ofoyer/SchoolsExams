﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolExams.Models;

namespace SchoolExams.Migrations
{
    [DbContext(typeof(SchoolsContext))]
    [Migration("20170220155320_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolExams.Models.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName");

                    b.HasKey("id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SchoolExams.Models.Exam", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExamName");

                    b.Property<int?>("QuestnaryIDid");

                    b.HasKey("id");

                    b.HasIndex("QuestnaryIDid");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("SchoolExams.Models.Questionary", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QuestName");

                    b.Property<int?>("SubjectIDid");

                    b.HasKey("id");

                    b.HasIndex("SubjectIDid");

                    b.ToTable("Questionaries");
                });

            modelBuilder.Entity("SchoolExams.Models.School", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("SchoolCityid");

                    b.Property<string>("SchoolCode");

                    b.Property<string>("SchoolName");

                    b.HasKey("id");

                    b.HasIndex("SchoolCityid");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("SchoolExams.Models.Subject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Schoolid");

                    b.Property<string>("SubjectName");

                    b.HasKey("id");

                    b.HasIndex("Schoolid");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SchoolExams.Models.Exam", b =>
                {
                    b.HasOne("SchoolExams.Models.Questionary", "QuestnaryID")
                        .WithMany("Exams")
                        .HasForeignKey("QuestnaryIDid");
                });

            modelBuilder.Entity("SchoolExams.Models.Questionary", b =>
                {
                    b.HasOne("SchoolExams.Models.Subject", "SubjectID")
                        .WithMany("Questionaries")
                        .HasForeignKey("SubjectIDid");
                });

            modelBuilder.Entity("SchoolExams.Models.School", b =>
                {
                    b.HasOne("SchoolExams.Models.City", "SchoolCity")
                        .WithMany()
                        .HasForeignKey("SchoolCityid");
                });

            modelBuilder.Entity("SchoolExams.Models.Subject", b =>
                {
                    b.HasOne("SchoolExams.Models.School")
                        .WithMany("Subjects")
                        .HasForeignKey("Schoolid");
                });
        }
    }
}
