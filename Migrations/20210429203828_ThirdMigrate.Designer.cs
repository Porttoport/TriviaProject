﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TriviaProject.Models;

namespace TriviaProject.Migrations
{
    [DbContext(typeof(TriviaContext))]
    [Migration("20210429203828_ThirdMigrate")]
    partial class ThirdMigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TriviaProject.Models.Duel", b =>
                {
                    b.Property<int>("DuelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("User1Id")
                        .HasColumnType("int");

                    b.Property<int>("User2Id")
                        .HasColumnType("int");

                    b.HasKey("DuelId");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.ToTable("Duels");
                });

            modelBuilder.Entity("TriviaProject.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DuelId")
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("correct_answer")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("difficulty")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("question")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ResultId");

                    b.HasIndex("DuelId");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("TriviaProject.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TriviaProject.Models.Duel", b =>
                {
                    b.HasOne("TriviaProject.Models.User", "User1")
                        .WithMany("User2Duels")
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TriviaProject.Models.User", "User2")
                        .WithMany("User1Duels")
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TriviaProject.Models.Result", b =>
                {
                    b.HasOne("TriviaProject.Models.Duel", null)
                        .WithMany("Trivia")
                        .HasForeignKey("DuelId");
                });
#pragma warning restore 612, 618
        }
    }
}
