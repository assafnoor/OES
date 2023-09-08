﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OES.EF;

#nullable disable

namespace OES.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230908104521_AddTabelsOES")]
    partial class AddTabelsOES
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OES.Core.Models.C_Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("no_Question")
                        .HasColumnType("int");

                    b.Property<int?>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("LecturerId");

                    b.ToTable("C_Exams");
                });

            modelBuilder.Entity("OES.Core.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("OES.Core.Models.Course_Department", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses_Departments");
                });

            modelBuilder.Entity("OES.Core.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("OES.Core.Models.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("OES.Core.Models.Lecturer_Room", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "LecturerId");

                    b.HasIndex("LecturerId");

                    b.ToTable("Lecturers_Rooms");
                });

            modelBuilder.Entity("OES.Core.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Crerate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<string>("ans1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ans2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ans3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ans4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correctAns")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ques")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("LecturerId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("OES.Core.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("OES.Core.Models.S_Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("C_ExamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("ListAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListQuestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("mark")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("totalIsCorrect")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("C_ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("S_Exams");
                });

            modelBuilder.Entity("OES.Core.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("OES.Core.Models.C_Exam", b =>
                {
                    b.HasOne("OES.Core.Models.Course", "course")
                        .WithMany("c_Exams")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OES.Core.Models.Lecturer", "lecturer")
                        .WithMany("c_Exams")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("lecturer");
                });

            modelBuilder.Entity("OES.Core.Models.Course_Department", b =>
                {
                    b.HasOne("OES.Core.Models.Course", "courses")
                        .WithMany("course_departments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OES.Core.Models.Department", "departments")
                        .WithMany("course_departments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courses");

                    b.Navigation("departments");
                });

            modelBuilder.Entity("OES.Core.Models.Lecturer", b =>
                {
                    b.HasOne("OES.Core.Models.Course", "course")
                        .WithMany("lecturers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("OES.Core.Models.Lecturer_Room", b =>
                {
                    b.HasOne("OES.Core.Models.Lecturer", "lecturer")
                        .WithMany("lecturers_rooms")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OES.Core.Models.Room", "room")
                        .WithMany("lecturers_rooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lecturer");

                    b.Navigation("room");
                });

            modelBuilder.Entity("OES.Core.Models.Question", b =>
                {
                    b.HasOne("OES.Core.Models.Course", "course")
                        .WithMany("questions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OES.Core.Models.Lecturer", "lecturer")
                        .WithMany("questions")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("lecturer");
                });

            modelBuilder.Entity("OES.Core.Models.Room", b =>
                {
                    b.HasOne("OES.Core.Models.Department", "department")
                        .WithMany("rooms")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("OES.Core.Models.S_Exam", b =>
                {
                    b.HasOne("OES.Core.Models.C_Exam", "c_exam")
                        .WithMany("s_exams")
                        .HasForeignKey("C_ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OES.Core.Models.Student", "student")
                        .WithMany("s_exams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("c_exam");

                    b.Navigation("student");
                });

            modelBuilder.Entity("OES.Core.Models.Student", b =>
                {
                    b.HasOne("OES.Core.Models.Room", "room")
                        .WithMany("students")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");
                });

            modelBuilder.Entity("OES.Core.Models.C_Exam", b =>
                {
                    b.Navigation("s_exams");
                });

            modelBuilder.Entity("OES.Core.Models.Course", b =>
                {
                    b.Navigation("c_Exams");

                    b.Navigation("course_departments");

                    b.Navigation("lecturers");

                    b.Navigation("questions");
                });

            modelBuilder.Entity("OES.Core.Models.Department", b =>
                {
                    b.Navigation("course_departments");

                    b.Navigation("rooms");
                });

            modelBuilder.Entity("OES.Core.Models.Lecturer", b =>
                {
                    b.Navigation("c_Exams");

                    b.Navigation("lecturers_rooms");

                    b.Navigation("questions");
                });

            modelBuilder.Entity("OES.Core.Models.Room", b =>
                {
                    b.Navigation("lecturers_rooms");

                    b.Navigation("students");
                });

            modelBuilder.Entity("OES.Core.Models.Student", b =>
                {
                    b.Navigation("s_exams");
                });
#pragma warning restore 612, 618
        }
    }
}
