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
    [Migration("20230319184909_ElementsInit")]
    partial class ElementsInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LootManagerApi.Entities.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Elements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description of the element",
                            LocationAddress = "Location undifined",
                            Name = "element1",
                            Type = "Type undefined ",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description of the element",
                            LocationAddress = "Location undifined",
                            Name = "element2",
                            Type = "Type undefined ",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description of the element",
                            LocationAddress = "Location undifined",
                            Name = "element3",
                            Type = "Type undefined ",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description of the element",
                            LocationAddress = "Location undifined",
                            Name = "element4",
                            Type = "Type undefined ",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description of the element",
                            LocationAddress = "Location undifined",
                            Name = "element5",
                            Type = "Type undefined ",
                            UserId = 5
                        });
                });

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
                            CreatedAt = new DateTime(2023, 3, 19, 18, 49, 8, 764, DateTimeKind.Utc).AddTicks(9175),
                            Email = "test@test.com",
                            FullName = "test",
                            PasswordHash = "$2a$11$NPuYfchS20fQHeHHXoQrwO5IEGpxrliXBPqLRAfhHLsIYOH.aOoou"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 3, 19, 18, 49, 8, 927, DateTimeKind.Utc).AddTicks(6543),
                            Email = "jerry@aol.com",
                            FullName = "Jerry Seinfeld",
                            PasswordHash = "$2a$11$KZ6Wlf8Rd22PQWv2vgoRDeNW3JU0rfLG0TGU4vi0IwpZ9MQEvqVJe"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 3, 19, 18, 49, 9, 87, DateTimeKind.Utc).AddTicks(4033),
                            Email = "George.Costanza@aol.com",
                            FullName = "George Costanza",
                            PasswordHash = "$2a$11$d31w9x3DrAeoVUsB52kQp./exXArkxCWGUz9QJ.wK2ebjQXRcLPFm"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 3, 19, 18, 49, 9, 242, DateTimeKind.Utc).AddTicks(6302),
                            Email = "Elaine.Benes@aol.com",
                            FullName = "Elaine Benes",
                            PasswordHash = "$2a$11$m.HgrKOyyBWxX.pisf4A8.KiVopMCT9awYLG4zb8Q8jReTe31d94m"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 3, 19, 18, 49, 9, 403, DateTimeKind.Utc).AddTicks(9005),
                            Email = "Cosmo.Kramer@aol.com",
                            FullName = "Cosmo Kramer",
                            PasswordHash = "$2a$11$mqBAvLZQhlhruiFW/82YcunWf/MDILam2d6rfOxKEC3xabTiI4Awi"
                        });
                });

            modelBuilder.Entity("LootManagerApi.Entities.Element", b =>
                {
                    b.HasOne("LootManagerApi.Entities.User", "User")
                        .WithMany("Elements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LootManagerApi.Entities.User", b =>
                {
                    b.Navigation("Elements");
                });
#pragma warning restore 612, 618
        }
    }
}