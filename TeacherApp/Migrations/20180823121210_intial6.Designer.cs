﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeacherApp.Models;

namespace TeacherApp.Migrations
{
    [DbContext(typeof(TeacherAppContext))]
    [Migration("20180823121210_intial6")]
    partial class intial6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeacherApp.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName");

                    b.Property<int>("Credits");

                    b.Property<int?>("DegreeID");

                    b.Property<int?>("TeacherID");

                    b.HasKey("CourseID");

                    b.HasIndex("DegreeID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TeacherApp.Models.Degree", b =>
                {
                    b.Property<int>("DegreeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DegreeName");

                    b.Property<int>("DurationinYears");

                    b.Property<int?>("InstitutionID");

                    b.HasKey("DegreeID");

                    b.HasIndex("InstitutionID");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("TeacherApp.Models.Institution", b =>
                {
                    b.Property<int>("InstitutionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InstitutionType");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("InstitutionID");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("TeacherApp.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("TeacherApp.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Published");

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewContent");

                    b.Property<int>("TeacherID");

                    b.HasKey("ReviewID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("TeacherApp.Models.Student", b =>
                {
                    b.HasBaseType("TeacherApp.Models.Person");

                    b.Property<int?>("DegreeID");

                    b.Property<int?>("InstitutionID");

                    b.HasIndex("DegreeID");

                    b.HasIndex("InstitutionID");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("TeacherApp.Models.Teacher", b =>
                {
                    b.HasBaseType("TeacherApp.Models.Person");

                    b.Property<string>("About");

                    b.Property<DateTime>("Graduated");

                    b.Property<string>("ImagePath");

                    b.Property<int?>("InstitutionID")
                        .HasColumnName("Teacher_InstitutionID");

                    b.Property<int>("LessonPrice");

                    b.Property<int>("Rating");

                    b.HasIndex("InstitutionID");

                    b.ToTable("Teachers");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("TeacherApp.Models.Course", b =>
                {
                    b.HasOne("TeacherApp.Models.Degree")
                        .WithMany("courses")
                        .HasForeignKey("DegreeID");

                    b.HasOne("TeacherApp.Models.Teacher")
                        .WithMany("Tutoring")
                        .HasForeignKey("TeacherID");
                });

            modelBuilder.Entity("TeacherApp.Models.Degree", b =>
                {
                    b.HasOne("TeacherApp.Models.Institution", "institution")
                        .WithMany()
                        .HasForeignKey("InstitutionID");
                });

            modelBuilder.Entity("TeacherApp.Models.Review", b =>
                {
                    b.HasOne("TeacherApp.Models.Teacher")
                        .WithMany("Reviews")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeacherApp.Models.Student", b =>
                {
                    b.HasOne("TeacherApp.Models.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeID");

                    b.HasOne("TeacherApp.Models.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionID");
                });

            modelBuilder.Entity("TeacherApp.Models.Teacher", b =>
                {
                    b.HasOne("TeacherApp.Models.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionID");
                });
#pragma warning restore 612, 618
        }
    }
}