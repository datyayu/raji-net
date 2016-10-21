using Microsoft.VisualStudio.TestTools.UnitTesting;
using RajiNet.Repositories;
using Moq;
using System.Collections.Generic;
using RajiNet.Controllers;
using RajiNet.ViewModels;
using System;
using RajiNet.Models;

namespace RajiNet
{
    [TestClassAttribute]
    public class AlbumControllerTest
    {
    #region IndexTests
        [TestMethod]
        public void Index__should_return_a_list_of_two_albums()
        {
            var mockRepo = new Mock<IRepository<Album, AlbumVM>>();
            mockRepo
                .Setup(repo => repo.GetAll())
                .Returns(GetTestAlbums());
            var controller = new AlbumController(mockRepo.Object);

            var results = controller.Index();
            Assert.AreEqual(results.Count, 2);
        }

        [TestMethod]
        public void Index__should_return_a_list_with_one_album_only()
        {
            var mockRepo = new Mock<IRepository<Album, AlbumVM>>();
            mockRepo
                .Setup(repo => repo.GetAll())
                .Returns(GetTestAlbums().GetRange(0, 1));
            var controller = new AlbumController(mockRepo.Object);

            var results = controller.Index();
            Assert.AreEqual(results.Count, 1);
        }

        [TestMethod]
        public void Index__should_return_an_empty_album_list()
        {
            var mockRepo = new Mock<IRepository<Album, AlbumVM>>();
            mockRepo
                .Setup(repo => repo.GetAll())
                .Returns(new List<AlbumVM>());
            var controller = new AlbumController(mockRepo.Object);

            var results = controller.Index();
            Assert.AreEqual(results.Count, 0);
        }

        [TestMethod]
        public void Index__returned_items_should_be_AlbumVM_instances()
        {
            var mockRepo = new Mock<IRepository<Album, AlbumVM>>();
            mockRepo
                .Setup(repo => repo.GetAll())
                .Returns(GetTestAlbums());
            var controller = new AlbumController(mockRepo.Object);

            var results = controller.Index();
            Assert.AreEqual(results.Count, 2);
            Assert.IsInstanceOfType(results[0], typeof(AlbumVM));
            Assert.IsInstanceOfType(results[1], typeof(AlbumVM));
        }
    #endregion

    #region ShowTests
        [TestMethod]
        public void Show__should_return_an_AlbumVM()
        {
            var mockRepo = new Mock<IRepository<Album, AlbumVM>>();
            mockRepo
                .Setup(repo => repo.GetAll())
                .Returns(GetTestAlbums());
            var controller = new AlbumController(mockRepo.Object);

            var result = controller.Show(1);
            Assert.IsInstanceOfType(result, typeof(AlbumVM));
        }

        [TestMethod]
        public void Show__should_return_the_correct_item()
        {
            var mockRepo = new Mock<IRepository<Album, AlbumVM>>();
            mockRepo
                .Setup(repo => repo.GetById(2))
                .Returns(GetTestAlbums().Find(album => album.Id == 2));
            var controller = new AlbumController(mockRepo.Object);

            var result = controller.Show(2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 2);
            Assert.AreSame(result.Name, "Absolute Soul");
            Assert.AreSame(result.Image, "/assets/images/albums/absoluteSoul.jpg");
        }

        // TODO: Implemente error message/ not found
    #endregion

    #region MockDataSetup
        private List<AlbumVM> GetTestAlbums()
        {
            var albums = new List<AlbumVM>
            {
                new AlbumVM
                {
                    Id = 1,
                    Name = "Hafa Adai",
                    Image =  "/assets/images/albums/hafaAdai.jpg",
                    ReleaseDate = DateTime.Now,
                    Artists = new List<AlbumArtistVM> 
                    {
                        new AlbumArtistVM 
                        {
                            Id = 3,
                            Image = "/assets/images/artists/iguigu.jpg",
                            Name = "Iguchi Yuka",
                            Biography = ""
                        },
                    },
                    Songs=new List<AlbumSongVM> 
                    {
                        new AlbumSongVM
                        {
                            Id = 1,
                            Name = "Absolute Soul",
                            Image = null,
                            FileUrl = "/assets/audio/absolutesoul.mp3",
                            Artists = new List<AlbumSongArtistVM>
                            {
                                new AlbumSongArtistVM
                                {
                                    Id = 3,
                                    Name = "Iguchi Yuka",
                                    Image = "/assets/images/artists/iguigu.jpg"
                                },
                            },
                        },
                    },
                },
                new AlbumVM
                {
                    Id = 2,
                    Name = "Absolute Soul",
                    Image = "/assets/images/albums/absoluteSoul.jpg",
                    ReleaseDate = DateTime.Now,
                    Artists = new List<AlbumArtistVM>
                    {
                        new AlbumArtistVM
                        {
                            Id = 1,
                            Image = "/assets/images/artists/konomi.jpg",
                            Name = "Konomi Suzuki",
                            Biography = "",
                        },
                    },

                    Songs = new List<AlbumSongVM>
                    {
                        new AlbumSongVM
                        {
                            Id = 2,
                            Name = "Absolute Soul",
                            Image = null,
                            FileUrl = "/assets/audio/absolutesoul.mp3",
                            Artists = new List<AlbumSongArtistVM>
                            {
                                new AlbumSongArtistVM 
                                {
                                    Id=1,
                                    Name = "Konomi Suzuki",
                                    Image = "/assets/images/artists/konomi.jpg"
                                },
                            },
                        },
                    },
                },
            };

            return albums;
        }
    #endregion
    }
}