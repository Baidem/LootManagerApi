﻿// <auto-generated />
using System;
using LootManagerApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LootManagerApi.Migrations
{
    [DbContext(typeof(LootManagerContext))]
    [Migration("20230317094422_userDates")]
    partial class userDates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LootManagerApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jerry@aol.com",
                            FullName = "Jerry Seinfeld",
                            PasswordHash = "$2a$11$rxpCvf8HIF7joH448JzzdOj8PAvVs6ZsLMrjH96sOeZTz2VafjFMm"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "George.Costanza@aol.com",
                            FullName = "George Costanza",
                            PasswordHash = "$2a$11$tlhOMMnscikibGD8AZZhqezFxP80ombQnNKXU2Wd.GdebLu5hLDDC"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Elaine.Benes@aol.com",
                            FullName = "Elaine Benes",
                            PasswordHash = "$2a$11$UaNaMRA7Qj1OxU/t9xUHAO0mF.f2kcc9t4sBEGko25WwrzAkkDYsa"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Cosmo.Kramer@aol.com",
                            FullName = "Cosmo Kramer",
                            PasswordHash = "$2a$11$rJ3i8Qbxy2zFMuDyl5SoSOv./yQ/MIxiwUHQF/JJ35Pc88RQfLoBK"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}