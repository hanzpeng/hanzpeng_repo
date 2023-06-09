﻿// <auto-generated />
using System;
using FullStack.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FullStack.API.Migrations
{
    [DbContext(typeof(FullStackDbContext))]
    [Migration("20230527233827_MakeCityNull")]
    partial class MakeCityNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FullStack.API.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("FullStack.API.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("FullStack.API.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<long>("Salary")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FullStack.API.Models.EmployeeCourse", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeeId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("EmployeeCourses");
                });

            modelBuilder.Entity("FullStack.API.Models.Employee", b =>
                {
                    b.HasOne("FullStack.API.Models.City", null)
                        .WithMany("Employees")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("FullStack.API.Models.EmployeeCourse", b =>
                {
                    b.HasOne("FullStack.API.Models.Course", "Course")
                        .WithMany("EmployeeCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStack.API.Models.Employee", "Employee")
                        .WithMany("EmployeeCourses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("FullStack.API.Models.City", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("FullStack.API.Models.Course", b =>
                {
                    b.Navigation("EmployeeCourses");
                });

            modelBuilder.Entity("FullStack.API.Models.Employee", b =>
                {
                    b.Navigation("EmployeeCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
