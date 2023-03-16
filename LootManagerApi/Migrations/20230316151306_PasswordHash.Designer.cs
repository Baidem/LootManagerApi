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
    [Migration("20230316151306_PasswordHash")]
    partial class PasswordHash
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

                    b.Property<string>("PasswordHash")
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
                            PasswordHash = "$2a$11$YVqNWFz2sI3b.Oie3NQ76.1X31UF0vGw5/p38jPMmonRpmjuQ98cS"
                        },
                        new
                        {
                            Id = 2,
                            Email = "George.Costanza@aol.com",
                            FullName = "George Costanza",
                            PasswordHash = "$2a$11$jpHPAzk4g8CO.lBOLK8D6eBvLaSkad6Fz9rdgd54dB0Alqnd7VRE2"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Elaine.Benes@aol.com",
                            FullName = "Elaine Benes",
                            PasswordHash = "$2a$11$dEd/XsjW4rEHwrEo4AB7f.ob.JnCSF7xhyKAcMZr2kdDtirNMyhDC"
                        },
                        new
                        {
                            Id = 4,
                            Email = "Cosmo.Kramer@aol.com",
                            FullName = "Cosmo Kramer",
                            PasswordHash = "$2a$11$KKeHQ4C/tFE2wCaixOryHe5HIuZIUFMj6/WwAsQz5K0TMFUZkYW7O"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
