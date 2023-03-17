﻿// <auto-generated />
using System;
using LootManagerApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LootManagerApi.Migrations
{
    [DbContext(typeof(LootManagerContext))]
    partial class LootManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Email = "test",
                            FullName = "test",
                            PasswordHash = "$2a$11$RM2zY2Tc/fdAZetrZ5HCU.dalOs9Vu9icMEeq11tIXMvTApzuI3J6"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jerry@aol.com",
                            FullName = "Jerry Seinfeld",
                            PasswordHash = "$2a$11$wVamX4LOjfVDcbek.V7rbe.bV9sye4paci/j1YswlPewYLHNasyVi"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "George.Costanza@aol.com",
                            FullName = "George Costanza",
                            PasswordHash = "$2a$11$6dLZn/Z3J.RVOoc1R79k2ehLgRfZCCWwmUOQrI6l4wqkalpqpQiMS"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Elaine.Benes@aol.com",
                            FullName = "Elaine Benes",
                            PasswordHash = "$2a$11$O1ZhJPYLMYX5hgGkSIG56.ALQPUuypywLng6qdJZ5xWDMRohGSSjy"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Cosmo.Kramer@aol.com",
                            FullName = "Cosmo Kramer",
                            PasswordHash = "$2a$11$a.cPDT8gtYIhnf1kZLBRtOEmixO1zmDlURTYR7xl6ODNwLq1eup.a"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
