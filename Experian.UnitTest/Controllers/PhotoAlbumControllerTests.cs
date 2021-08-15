using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Experian.Services.WebRequest;
using Experian.Services.PhotoAlbum;
using Experian.Models.PhotoAlbum;
using ExperianCodeTest.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Experian.UnitTest.Controllers
{
    [TestClass]
    public class PhotoAlbumControllerTests
    {
        private Mock<IPhotoAlbumService> _photoAlbumServiceMoq;
        private PhotoAlbumController _photoAlbumController;

        private List<Album> _albums;

        [TestInitialize]
        public void Initialize()
        {
            _albums = new List<Album> { new Album { Id = 1, UserId = 1 } };
            _photoAlbumServiceMoq = new Mock<IPhotoAlbumService>();
            _photoAlbumServiceMoq.Setup(x => x.Get()).Returns(_albums);
            _photoAlbumServiceMoq.Setup(x => x.GetById(1)).Returns(_albums);
            _photoAlbumController = new PhotoAlbumController(_photoAlbumServiceMoq.Object);
        }

        [TestMethod]
        public void TestPhotoAlbumControllerGet()
        {
            //act
            IActionResult result = _photoAlbumController.Get();

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        [DataRow(1)]
        public void TestPhotoAlbumControllerGetById(int id)
        {
            //act
            IActionResult result = _photoAlbumController.GetById(id);

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is OkObjectResult);
        }
    }
}
