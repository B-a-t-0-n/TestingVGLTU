﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestingVGLTU.Data;

#nullable disable

namespace TestingVGLTU.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestingVGLTU.Data.Entities.ActiveTesting", b =>
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

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Question", b =>
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

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Testing", b =>
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

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeTestingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TypeTestingId");

                    b.ToTable("Testings");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.TypeTesting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeTestings");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.QuestionInputNumber", b =>
                {
                    b.HasBaseType("TestingVGLTU.Data.Entities.Question");

                    b.Property<string>("CorrectAnswers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("QuestionInputNumbers");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.QuestionInputText", b =>
                {
                    b.HasBaseType("TestingVGLTU.Data.Entities.Question");

                    b.Property<string>("CorrectAnswers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("QuestionInputText");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.QuestionMultipleChoice", b =>
                {
                    b.HasBaseType("TestingVGLTU.Data.Entities.Question");

                    b.Property<string>("AnswerOptions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("QuestionMultipleChoices");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.QuestionSingleSelection", b =>
                {
                    b.HasBaseType("TestingVGLTU.Data.Entities.Question");

                    b.Property<string>("AnswerOptions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("QuestionSingleSelections");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Student", b =>
                {
                    b.HasBaseType("TestingVGLTU.Data.Entities.User");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("NumberRecordBook")
                        .HasColumnType("int");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Teacher", b =>
                {
                    b.HasBaseType("TestingVGLTU.Data.Entities.User");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.ActiveTesting", b =>
                {
                    b.HasOne("TestingVGLTU.Data.Entities.Group", "Group")
                        .WithMany("ActiveTestings")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingVGLTU.Data.Entities.Testing", "Testing")
                        .WithMany("ActiveTestings")
                        .HasForeignKey("TestingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Testing");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Question", b =>
                {
                    b.HasOne("TestingVGLTU.Data.Entities.Testing", "Testing")
                        .WithMany("Questions")
                        .HasForeignKey("TestingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Testing");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Testing", b =>
                {
                    b.HasOne("TestingVGLTU.Data.Entities.Teacher", "Teacher")
                        .WithMany("Testings")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingVGLTU.Data.Entities.TypeTesting", "TypeTesting")
                        .WithMany("Testings")
                        .HasForeignKey("TypeTestingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("TypeTesting");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.QuestionInputNumber", b =>
                {
                    b.HasOne("TestingVGLTU.Data.Entities.Question", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Data.Entities.QuestionInputNumber", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.QuestionInputText", b =>
                {
                    b.HasOne("TestingVGLTU.Data.Entities.Question", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Data.Entities.QuestionInputText", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.QuestionMultipleChoice", b =>
                {
                    b.HasOne("TestingVGLTU.Data.Entities.Question", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Data.Entities.QuestionMultipleChoice", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.QuestionSingleSelection", b =>
                {
                    b.HasOne("TestingVGLTU.Data.Entities.Question", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Data.Entities.QuestionSingleSelection", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Student", b =>
                {
                    b.HasOne("TestingVGLTU.Data.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingVGLTU.Data.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Data.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Teacher", b =>
                {
                    b.HasOne("TestingVGLTU.Data.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("TestingVGLTU.Data.Entities.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Group", b =>
                {
                    b.Navigation("ActiveTestings");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Testing", b =>
                {
                    b.Navigation("ActiveTestings");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.TypeTesting", b =>
                {
                    b.Navigation("Testings");
                });

            modelBuilder.Entity("TestingVGLTU.Data.Entities.Teacher", b =>
                {
                    b.Navigation("Testings");
                });
#pragma warning restore 612, 618
        }
    }
}
