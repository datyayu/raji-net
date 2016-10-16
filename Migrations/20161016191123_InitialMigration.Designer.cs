using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RajiNet.Models;

namespace RajiNet.Migrations
{
    [DbContext(typeof(RajiNetDbContext))]
    [Migration("20161016191123_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("RajiNet.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<int?>("SeriesId");

                    b.Property<string>("SingleType");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("RajiNet.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("RajiNet.Models.Joins.AlbumArtist", b =>
                {
                    b.Property<int>("ArtistId");

                    b.Property<int>("AlbumId");

                    b.HasKey("ArtistId", "AlbumId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("AlbumArtist");
                });

            modelBuilder.Entity("RajiNet.Models.Joins.ArtistSong", b =>
                {
                    b.Property<int>("ArtistId");

                    b.Property<int>("SongId");

                    b.HasKey("ArtistId", "SongId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("SongId");

                    b.ToTable("ArtistSong");
                });

            modelBuilder.Entity("RajiNet.Models.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("RajiNet.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumId");

                    b.Property<string>("FileUrl");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("RajiNet.Models.Album", b =>
                {
                    b.HasOne("RajiNet.Models.Series")
                        .WithMany("Albums")
                        .HasForeignKey("SeriesId");
                });

            modelBuilder.Entity("RajiNet.Models.Joins.AlbumArtist", b =>
                {
                    b.HasOne("RajiNet.Models.Album", "Album")
                        .WithMany("AlbumArtist")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RajiNet.Models.Artist", "Artist")
                        .WithMany("AlbumArtist")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RajiNet.Models.Joins.ArtistSong", b =>
                {
                    b.HasOne("RajiNet.Models.Artist", "Artist")
                        .WithMany("ArtistSong")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RajiNet.Models.Song", "Song")
                        .WithMany("ArtistSong")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RajiNet.Models.Song", b =>
                {
                    b.HasOne("RajiNet.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");
                });
        }
    }
}
