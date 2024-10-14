﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagementSystem.Models;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20240907181132_addcoursesubjecttable")]
    partial class addcoursesubjecttable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentManagementSystem.Models.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("StudentManagementSystem.Models.CourseSubject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("courseid")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<int>("subjectid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("CourseSubjects");
                });

            modelBuilder.Entity("StudentManagementSystem.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("int");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("exams");
                });

            modelBuilder.Entity("StudentManagementSystem.Models.Grade", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("grades");
                });

            modelBuilder.Entity("StudentManagementSystem.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameWithInitials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("StudentManagementSystem.Models.StudentClass", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("StudentManagementSystem.Models.Subject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("StudentManagementSystem.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<int>("companyid")
                        .HasColumnType("int");

                    b.Property<bool>("isactive")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("property_id")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
