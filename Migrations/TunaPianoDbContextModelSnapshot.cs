﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tuna_Piano_API.Migrations
{
    [DbContext(typeof(TunaPianoDbContext))]
    partial class TunaPianoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tuna_Piano_API.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 30,
                            Bio = "Long running metal band",
                            Name = "Sevendust"
                        },
                        new
                        {
                            Id = 2,
                            Age = 30,
                            Bio = "All-time Tune Maker",
                            Name = "Hoobastank"
                        },
                        new
                        {
                            Id = 3,
                            Age = 30,
                            Bio = "Metal Fav",
                            Name = "Staind"
                        });
                });

            modelBuilder.Entity("Tuna_Piano_API.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Metal"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Rock"
                        });
                });

            modelBuilder.Entity("Tuna_Piano_API.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("interval");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Seasons",
                            ArtistId = 1,
                            GenreId = 2,
                            Length = new TimeSpan(0, 0, 3, 30, 0),
                            Title = "Broken Down"
                        },
                        new
                        {
                            Id = 2,
                            Album = "Hoobastank",
                            ArtistId = 2,
                            GenreId = 2,
                            Length = new TimeSpan(0, 0, 2, 55, 0),
                            Title = "Crawling in the Dark"
                        },
                        new
                        {
                            Id = 3,
                            Album = "Break the Cycle",
                            ArtistId = 3,
                            GenreId = 1,
                            Length = new TimeSpan(0, 0, 3, 20, 0),
                            Title = "Fade"
                        });
                });

            modelBuilder.Entity("Tuna_Piano_API.Models.Song", b =>
                {
                    b.HasOne("Tuna_Piano_API.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tuna_Piano_API.Models.Genre", "Genre")
                        .WithMany("Songs")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Tuna_Piano_API.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tuna_Piano_API.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
