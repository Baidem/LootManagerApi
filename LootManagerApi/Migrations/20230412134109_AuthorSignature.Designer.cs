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
    [Migration("20230412134109_AuthorSignature")]
    partial class AuthorSignature
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElementImage", b =>
                {
                    b.Property<int>("ElementsId")
                        .HasColumnType("int");

                    b.Property<int>("ImagesId")
                        .HasColumnType("int");

                    b.HasKey("ElementsId", "ImagesId");

                    b.HasIndex("ImagesId");

                    b.ToTable("ElementImage");
                });

            modelBuilder.Entity("ImageInfoSheet", b =>
                {
                    b.Property<int>("ImagesId")
                        .HasColumnType("int");

                    b.Property<int>("InfoSheetsId")
                        .HasColumnType("int");

                    b.HasKey("ImagesId", "InfoSheetsId");

                    b.HasIndex("InfoSheetsId");

                    b.ToTable("ImageInfoSheet");
                });

            modelBuilder.Entity("LootManagerApi.Entities.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InfoSheetId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InfoSheetId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Elements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description of the element",
                            Name = "figurine1",
                            Type = "Figurine ",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description of the element",
                            Name = "figurine2",
                            Type = "Figurine ",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description of the element",
                            Name = "figurine3",
                            Type = "Figurine ",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description of the element",
                            Name = "figurine4",
                            Type = "Figurine ",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description of the element",
                            Name = "figurine5",
                            Type = "Figurine ",
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            Description = "Description of the element",
                            Name = "manga1",
                            Type = "Manga",
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            Description = "Description of the element",
                            Name = "manga2",
                            Type = "Manga",
                            UserId = 2
                        },
                        new
                        {
                            Id = 8,
                            Description = "Description of the element",
                            Name = "manga3",
                            Type = "Manga",
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            Description = "Description of the element",
                            Name = "manga4",
                            Type = "Manga",
                            UserId = 4
                        },
                        new
                        {
                            Id = 10,
                            Description = "Description of the element",
                            Name = "manga5",
                            Type = "Manga",
                            UserId = 5
                        },
                        new
                        {
                            Id = 11,
                            Description = "Description of the element",
                            Name = "comic1",
                            Type = "Comic",
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            Description = "Description of the element",
                            Name = "comic2",
                            Type = "Comic",
                            UserId = 2
                        },
                        new
                        {
                            Id = 13,
                            Description = "Description of the element",
                            Name = "comic3",
                            Type = "Comic",
                            UserId = 3
                        },
                        new
                        {
                            Id = 14,
                            Description = "Description of the element",
                            Name = "comic4",
                            Type = "Comic",
                            UserId = 4
                        },
                        new
                        {
                            Id = 15,
                            Description = "Description of the element",
                            Name = "comic5",
                            Type = "Comic",
                            UserId = 5
                        });
                });

            modelBuilder.Entity("LootManagerApi.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("LootManagerApi.Entities.InfoSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorSignature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("WikiArticle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InfoSheets");
                });

            modelBuilder.Entity("LootManagerApi.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Furniture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("House")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Room")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shelf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Furniture = "Furniture1",
                            House = "House1",
                            Position = 1,
                            Room = "Room1",
                            Shelf = "First Shelf",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Furniture = "Furniture1",
                            House = "House1",
                            Position = 1,
                            Room = "Room2",
                            Shelf = "First Shelf",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Furniture = "Furniture1",
                            House = "House1",
                            Position = 1,
                            Room = "Room3",
                            Shelf = "First Shelf",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Furniture = "Furniture1",
                            House = "House2",
                            Position = 1,
                            Room = "Room1",
                            Shelf = "First Shelf",
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            Furniture = "Furniture1",
                            House = "House2",
                            Position = 1,
                            Room = "Room2",
                            Shelf = "First Shelf",
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            Furniture = "Furniture1",
                            House = "House2",
                            Position = 1,
                            Room = "Room3",
                            Shelf = "First Shelf",
                            UserId = 2
                        },
                        new
                        {
                            Id = 7,
                            Furniture = "Furniture1",
                            House = "House3",
                            Position = 1,
                            Room = "Room1",
                            Shelf = "First Shelf",
                            UserId = 3
                        },
                        new
                        {
                            Id = 8,
                            Furniture = "Furniture1",
                            House = "House3",
                            Position = 1,
                            Room = "Room2",
                            Shelf = "First Shelf",
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            Furniture = "Furniture1",
                            House = "House3",
                            Position = 1,
                            Room = "Room3",
                            Shelf = "First Shelf",
                            UserId = 3
                        },
                        new
                        {
                            Id = 10,
                            Furniture = "Furniture1",
                            House = "House4",
                            Position = 1,
                            Room = "Room1",
                            Shelf = "First Shelf",
                            UserId = 4
                        },
                        new
                        {
                            Id = 11,
                            Furniture = "Furniture1",
                            House = "House4",
                            Position = 1,
                            Room = "Room2",
                            Shelf = "First Shelf",
                            UserId = 4
                        },
                        new
                        {
                            Id = 12,
                            Furniture = "Furniture1",
                            House = "House4",
                            Position = 1,
                            Room = "Room3",
                            Shelf = "First Shelf",
                            UserId = 4
                        },
                        new
                        {
                            Id = 13,
                            Furniture = "Furniture1",
                            House = "House5",
                            Position = 1,
                            Room = "Room1",
                            Shelf = "First Shelf",
                            UserId = 5
                        },
                        new
                        {
                            Id = 14,
                            Furniture = "Furniture1",
                            House = "House5",
                            Position = 1,
                            Room = "Room2",
                            Shelf = "First Shelf",
                            UserId = 5
                        },
                        new
                        {
                            Id = 15,
                            Furniture = "Furniture1",
                            House = "House5",
                            Position = 1,
                            Room = "Room3",
                            Shelf = "First Shelf",
                            UserId = 5
                        });
                });

            modelBuilder.Entity("LootManagerApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorSignature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InfoSheetId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InfoSheetId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 4, 12, 13, 41, 8, 877, DateTimeKind.Utc).AddTicks(9649),
                            Email = "admin@loot.com",
                            FullName = "admin",
                            PasswordHash = "$2a$11$z0NVRJKZnLPfmzptMzrkb.B7n1tSfI23XOu89cgGdLhVocesieMfq",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 4, 12, 13, 41, 9, 38, DateTimeKind.Utc).AddTicks(363),
                            Email = "user@loot.com",
                            FullName = "user",
                            PasswordHash = "$2a$11$u5gaD8Ud/B4/C29lc61hBeVGDGx3nOQxnnN49wIBu5wNuugDJx78u",
                            Role = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 4, 12, 13, 41, 9, 199, DateTimeKind.Utc).AddTicks(4330),
                            Email = "contributor@loot.com",
                            FullName = "contributor",
                            PasswordHash = "$2a$11$bYZ0l5JOsx.qnvxhlpcLo.FlM7M7COp1GxgUS5Z2wrXPHNANAZGxO",
                            Role = 2
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 4, 12, 13, 41, 9, 374, DateTimeKind.Utc).AddTicks(5931),
                            Email = "user4@loot.com",
                            FullName = "user4",
                            PasswordHash = "$2a$11$ODU410tAR1ZoEio1CsRDb.pzKoHt31UhhBpiXOEx17bdgtyqwOaIq",
                            Role = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 4, 12, 13, 41, 9, 531, DateTimeKind.Utc).AddTicks(8937),
                            Email = "user5@loot.com",
                            FullName = "user5",
                            PasswordHash = "$2a$11$Prvzzkmc6uD34AmI.nLELuqRMVJmgjaBIdRb2DomQiOQxO0kAFjD.",
                            Role = 1
                        });
                });

            modelBuilder.Entity("ElementImage", b =>
                {
                    b.HasOne("LootManagerApi.Entities.Element", null)
                        .WithMany()
                        .HasForeignKey("ElementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LootManagerApi.Entities.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImageInfoSheet", b =>
                {
                    b.HasOne("LootManagerApi.Entities.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LootManagerApi.Entities.InfoSheet", null)
                        .WithMany()
                        .HasForeignKey("InfoSheetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LootManagerApi.Entities.Element", b =>
                {
                    b.HasOne("LootManagerApi.Entities.InfoSheet", null)
                        .WithMany("Elements")
                        .HasForeignKey("InfoSheetId");

                    b.HasOne("LootManagerApi.Entities.Location", "Location")
                        .WithMany("Elements")
                        .HasForeignKey("LocationId");

                    b.HasOne("LootManagerApi.Entities.User", "User")
                        .WithMany("Elements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LootManagerApi.Entities.Location", b =>
                {
                    b.HasOne("LootManagerApi.Entities.User", "User")
                        .WithMany("Locations")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LootManagerApi.Entities.User", b =>
                {
                    b.HasOne("LootManagerApi.Entities.InfoSheet", "InfoSheet")
                        .WithMany()
                        .HasForeignKey("InfoSheetId");

                    b.Navigation("InfoSheet");
                });

            modelBuilder.Entity("LootManagerApi.Entities.InfoSheet", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("LootManagerApi.Entities.Location", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("LootManagerApi.Entities.User", b =>
                {
                    b.Navigation("Elements");

                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}