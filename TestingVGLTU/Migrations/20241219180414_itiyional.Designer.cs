﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestingVGLTU.Data;

#nullable disable

namespace TestingVGLTU.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241219180414_itiyional")]
    partial class itiyional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestingVGLTU.Models.Entity.ActiveTesting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("TestingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TestingId");

                    b.ToTable("ActiveTesting");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ИС1-211-ОТ"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ИС1-212-ОТ"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ИС1-213-ОТ"
                        });
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Scores")
                        .HasColumnType("int");

                    b.Property<int>("TestingId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TestingId");

                    b.ToTable("Questions");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Testing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Attempts")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScoresFor3")
                        .HasColumnType("int");

                    b.Property<int?>("ScoresFor4")
                        .HasColumnType("int");

                    b.Property<int?>("ScoresFor5")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.Property<DateTime>("TimeCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeOutputOfResultId")
                        .HasColumnType("int");

                    b.Property<int>("TypeTestingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TypeOutputOfResultId");

                    b.HasIndex("TypeTestingId");

                    b.ToTable("Testings");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.TypeOutputOfResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TypeOutputOfResults");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "По окончанию"
                        },
                        new
                        {
                            Id = 2,
                            Name = "По завершению тестирования"
                        });
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.TypeTesting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TypeTestings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Олимпиада"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Тест"
                        });
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.UserResponsesToTests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActiveTestingId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActiveTestingId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("StudentId");

                    b.ToTable("UserResponsesToTests");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.QuestionInputNumber", b =>
                {
                    b.HasBaseType("TestingVGLTU.Models.Entity.Question");

                    b.Property<string>("CorrectAnswers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("QuestionInputNumbers");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.QuestionInputText", b =>
                {
                    b.HasBaseType("TestingVGLTU.Models.Entity.Question");

                    b.Property<string>("CorrectAnswers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("QuestionInputText");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.QuestionMultipleChoice", b =>
                {
                    b.HasBaseType("TestingVGLTU.Models.Entity.Question");

                    b.Property<string>("AnswerOptions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("QuestionMultipleChoices");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.QuestionSingleSelection", b =>
                {
                    b.HasBaseType("TestingVGLTU.Models.Entity.Question");

                    b.Property<string>("AnswerOptions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("QuestionSingleSelections");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Student", b =>
                {
                    b.HasBaseType("TestingVGLTU.Models.Entity.User");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("NumberRecordBook")
                        .HasColumnType("int");

                    b.HasIndex("GroupId");

                    b.HasIndex("NumberRecordBook")
                        .IsUnique()
                        .HasFilter("[NumberRecordBook] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Teacher", b =>
                {
                    b.HasBaseType("TestingVGLTU.Models.Entity.User");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.ActiveTesting", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.Group", "Group")
                        .WithMany("ActiveTestings")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingVGLTU.Models.Entity.Testing", "Testing")
                        .WithMany("ActiveTestings")
                        .HasForeignKey("TestingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Testing");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Question", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.Testing", "Testing")
                        .WithMany("Questions")
                        .HasForeignKey("TestingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Testing");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Testing", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.Teacher", "Teacher")
                        .WithMany("Testings")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingVGLTU.Models.Entity.TypeOutputOfResult", "TypeOutputOfResult")
                        .WithMany("Testings")
                        .HasForeignKey("TypeOutputOfResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingVGLTU.Models.Entity.TypeTesting", "TypeTesting")
                        .WithMany("Testings")
                        .HasForeignKey("TypeTestingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("TypeOutputOfResult");

                    b.Navigation("TypeTesting");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.UserResponsesToTests", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.ActiveTesting", "ActiveTesting")
                        .WithMany("UserResponsesToTests")
                        .HasForeignKey("ActiveTestingId");

                    b.HasOne("TestingVGLTU.Models.Entity.Question", "Question")
                        .WithMany("UserResponsesToTests")
                        .HasForeignKey("QuestionId");

                    b.HasOne("TestingVGLTU.Models.Entity.Student", "Student")
                        .WithMany("UserResponsesToTests")
                        .HasForeignKey("StudentId");

                    b.Navigation("ActiveTesting");

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.QuestionInputNumber", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.Question", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Models.Entity.QuestionInputNumber", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.QuestionInputText", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.Question", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Models.Entity.QuestionInputText", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.QuestionMultipleChoice", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.Question", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Models.Entity.QuestionMultipleChoice", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.QuestionSingleSelection", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.Question", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Models.Entity.QuestionSingleSelection", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Student", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingVGLTU.Models.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Models.Entity.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Teacher", b =>
                {
                    b.HasOne("TestingVGLTU.Models.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Models.Entity.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.ActiveTesting", b =>
                {
                    b.Navigation("UserResponsesToTests");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Group", b =>
                {
                    b.Navigation("ActiveTestings");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Question", b =>
                {
                    b.Navigation("UserResponsesToTests");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Testing", b =>
                {
                    b.Navigation("ActiveTestings");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.TypeOutputOfResult", b =>
                {
                    b.Navigation("Testings");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.TypeTesting", b =>
                {
                    b.Navigation("Testings");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Student", b =>
                {
                    b.Navigation("UserResponsesToTests");
                });

            modelBuilder.Entity("TestingVGLTU.Models.Entity.Teacher", b =>
                {
                    b.Navigation("Testings");
                });
#pragma warning restore 612, 618
        }
    }
}
