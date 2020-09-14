﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20200914100341_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ruslan",
                            Surname = "Dzobko"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alina",
                            Surname = "Trykoz"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Max",
                            Surname = "Maluk"
                        });
                });

            modelBuilder.Entity("Data.Entities.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fired")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hired")
                        .HasColumnType("datetime2");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("EmployeePositions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 2,
                            Hired = new DateTime(2017, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = 4,
                            Salary = 1000.0
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 1,
                            Hired = new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = 1,
                            Salary = 2500.0
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 2,
                            Fired = new DateTime(2017, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Hired = new DateTime(2016, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = 3,
                            Salary = 800.0
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 3,
                            Hired = new DateTime(2018, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = 2,
                            Salary = 1300.0
                        });
                });

            modelBuilder.Entity("Data.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Dev"
                        },
                        new
                        {
                            Id = 2,
                            Title = "QA"
                        },
                        new
                        {
                            Id = 3,
                            Title = "BA"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Manager"
                        });
                });

            modelBuilder.Entity("Data.Entities.EmployeePosition", b =>
                {
                    b.HasOne("Data.Entities.Employee", "Employee")
                        .WithMany("Positions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}