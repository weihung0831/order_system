﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using order_system.Data;

#nullable disable

namespace order_system.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("order_system.Models.MealSelection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("MenuId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SelectionDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("UserId");

                    b.ToTable("MealSelections");
                });

            modelBuilder.Entity("order_system.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("order_system.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("order_system.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(5);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(4);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(6);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8470),
                            Email = "admin@example.com",
                            Password = "123456",
                            RoleId = 1,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8470),
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8520),
                            Email = "user0@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8530),
                            Username = "user0"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8540),
                            Email = "user1@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8540),
                            Username = "user1"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8560),
                            Email = "user2@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8560),
                            Username = "user2"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8570),
                            Email = "user3@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8570),
                            Username = "user3"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8600),
                            Email = "user4@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8600),
                            Username = "user4"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8610),
                            Email = "user5@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8610),
                            Username = "user5"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8620),
                            Email = "user6@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8620),
                            Username = "user6"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8640),
                            Email = "user7@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8640),
                            Username = "user7"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8660),
                            Email = "user8@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8660),
                            Username = "user8"
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8670),
                            Email = "user9@example.com",
                            Password = "123456",
                            RoleId = 2,
                            UpdatedAt = new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8670),
                            Username = "user9"
                        });
                });

            modelBuilder.Entity("order_system.Models.MealSelection", b =>
                {
                    b.HasOne("order_system.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("order_system.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("User");
                });

            modelBuilder.Entity("order_system.Models.User", b =>
                {
                    b.HasOne("order_system.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("order_system.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
