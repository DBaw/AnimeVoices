﻿// <auto-generated />
using AnimeVoices.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimeVoices.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("AnimeVoices.DataModels.Entities.AnimeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aired")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Characters")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Episodes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Studio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Anime");
                });

            modelBuilder.Entity("AnimeVoices.DataModels.Entities.AnimePaginationEntity", b =>
                {
                    b.Property<string>("Properties")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasNextPage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Page")
                        .HasColumnType("INTEGER");

                    b.HasKey("Properties");

                    b.ToTable("AnimePagination");
                });

            modelBuilder.Entity("AnimeVoices.DataModels.Entities.CharacterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Seiyuu")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("AnimeVoices.DataModels.Entities.SeiyuuEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Seiyuu");
                });
#pragma warning restore 612, 618
        }
    }
}
