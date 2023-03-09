﻿// <auto-generated />
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
    [Migration("20230309185508_Init")]
    partial class Init
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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jerry@aol.com",
                            FullName = "Jerry Seinfeld",
                            Password = "pwd"
                        },
                        new
                        {
                            Id = 2,
                            Email = "George.Costanza@aol.com",
                            FullName = "George Costanza",
                            Password = "george"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Elaine.Benes@aol.com",
                            FullName = "Elaine Benes",
                            Password = "jerry"
                        },
                        new
                        {
                            Id = 4,
                            Email = "Cosmo.Kramer@aol.com",
                            FullName = "Cosmo Kramer",
                            Password = "qzerty"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
