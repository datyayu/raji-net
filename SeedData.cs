using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RajiNet.Models;
using RajiNet.Models.Joins;

public class SeedData
{
    public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
    {
        using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            using (var db = serviceScope.ServiceProvider.GetService<RajiNetDbContext>())
            {
                db.Database.EnsureDeleted();
                await db.Database.MigrateAsync();
                db.Database.EnsureCreated();
                InsertTestData(db);
            }
        }
    }


    private static void InsertTestData(RajiNetDbContext db)
    {
        /* Series */

        var absoluteSoul = new Series { 
            Name="Absolute Soul", 
            Image="/assets/img/series/absoluteduo.jpg",
        };
        var gochiUsa = new Series { 
            Name="Gochuumon wa Usagi Desu Ka?", 
            Image="/assets/img/series/gochiusa.jpg",
        };
        var saeKano = new Series {
            Name="Saenai Heroine no Sodate Kata", 
            Image="/assets/img/series/saekano.jpg",
        };


        /* Artists */

        var iguchiYuka = new Artist { 
            Name="Iguchi Yuka", 
            Image="/assets/images/artists/iguigu.jpg",
        };
        var asumiKana = new Artist { 
            Name="AsumiKana", 
            Image="/assets/images/artists/asumin.jpg",
        };
        var konomiSuzuki = new Artist {
            Name="Konomi Suzuki", 
            Image="/assets/images/artists/konomi.jpg",
        };


        /* Albums */

        var hafaAdai = new Album { 
            Name="Hafa Adai", 
            Image="/assets/images/albums/hafaAdai.jpg",
            ReleaseDate=DateTime.Now,
            SingleType=SingleType.Album,
        };
        var absoluteSoulAlbum = new Album {
            Name="Absolute Soul",
            Image="/assets/images/albums/absoluteSoul.jpg",
            ReleaseDate=DateTime.Now,
            SingleType=SingleType.OpSingle,
        };


        /* Songs */

        var absoluteSoulSong = new Song {
            Name="Absolute Soul",
            FileUrl="/assets/audio/absolutesoul.mp3",
            Album=absoluteSoulAlbum,
        };
        var puengue = new Song {
            Name="Absolute Soul",
            FileUrl="/assets/audio/absolutesoul.mp3",
            Album=hafaAdai,
        };


        /* Album-Series joins */

        absoluteSoul.Albums.Add(absoluteSoulAlbum);


        /* Album-Song joins */

        absoluteSoulAlbum.Songs.Add(absoluteSoulSong);
        hafaAdai.Songs.Add(puengue);


        /* Album-Artist joins */

        var iguchiYukaHafaAdaiJoin = new AlbumArtist();
        iguchiYukaHafaAdaiJoin.Artist = iguchiYuka;
        iguchiYukaHafaAdaiJoin.Album = hafaAdai;
        hafaAdai.AlbumArtist.Add(iguchiYukaHafaAdaiJoin);
        iguchiYuka.AlbumArtist.Add(iguchiYukaHafaAdaiJoin);

        var konomiSuzukiAbsoluteSoulJoin = new AlbumArtist();
        konomiSuzukiAbsoluteSoulJoin.Artist = konomiSuzuki;
        konomiSuzukiAbsoluteSoulJoin.Album = absoluteSoulAlbum;
        konomiSuzuki.AlbumArtist.Add(konomiSuzukiAbsoluteSoulJoin);
        absoluteSoulAlbum.AlbumArtist.Add(konomiSuzukiAbsoluteSoulJoin);


        /* Artist-Song joins */

        var iguchiYukaPuengueJoin = new ArtistSong();
        iguchiYukaPuengueJoin.Artist = iguchiYuka;
        iguchiYukaPuengueJoin.Song = puengue;
        puengue.ArtistSong.Add(iguchiYukaPuengueJoin);
        iguchiYuka.ArtistSong.Add(iguchiYukaPuengueJoin);

        var konomiSuzukiAbsoluteSoulSongJoin = new ArtistSong();
        konomiSuzukiAbsoluteSoulSongJoin.Artist = konomiSuzuki;
        konomiSuzukiAbsoluteSoulSongJoin.Song = absoluteSoulSong;
        absoluteSoulSong.ArtistSong.Add(konomiSuzukiAbsoluteSoulSongJoin);
        konomiSuzuki.ArtistSong.Add(konomiSuzukiAbsoluteSoulSongJoin);
        

        /* Add all to db */

        var series = new List<Series>();
        series.Add(absoluteSoul);
        series.Add(gochiUsa);
        series.Add(saeKano);
        db.Series.AddRange(series);

        var artists = new List<Artist>();
        artists.Add(asumiKana);
        artists.Add(iguchiYuka);
        artists.Add(konomiSuzuki);
        db.Artists.AddRange(artists);

        var albums = new List<Album>();
        albums.Add(hafaAdai);
        albums.Add(absoluteSoulAlbum);
        db.Albums.AddRange(albums);

        var songs = new List<Song>();
        songs.Add(absoluteSoulSong);
        songs.Add(puengue);
        db.Songs.AddRange(songs);        

        db.SaveChanges();
    }
}