﻿// <auto-generated />
using EF_Core_Load_Related_Data.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Core_Load_Related_Data.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221103154711_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EF_Core_Load_Related_Data.Api.Data.Comic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Marvel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "DC"
                        });
                });

            modelBuilder.Entity("EF_Core_Load_Related_Data.Api.Data.SuperHero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("SuperHeroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Spiderman",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Iron Man",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Batman",
                            TeamId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Wonder Woman",
                            TeamId = 2
                        });
                });

            modelBuilder.Entity("EF_Core_Load_Related_Data.Api.Data.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ComicId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComicId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ComicId = 1,
                            Name = "Avengers"
                        },
                        new
                        {
                            Id = 2,
                            ComicId = 2,
                            Name = "Justice League"
                        });
                });

            modelBuilder.Entity("EF_Core_Load_Related_Data.Api.Data.SuperHero", b =>
                {
                    b.HasOne("EF_Core_Load_Related_Data.Api.Data.Team", null)
                        .WithMany("SuperHeroes")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EF_Core_Load_Related_Data.Api.Data.Team", b =>
                {
                    b.HasOne("EF_Core_Load_Related_Data.Api.Data.Comic", null)
                        .WithMany("Teams")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EF_Core_Load_Related_Data.Api.Data.Comic", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("EF_Core_Load_Related_Data.Api.Data.Team", b =>
                {
                    b.Navigation("SuperHeroes");
                });
#pragma warning restore 612, 618
        }
    }
}
