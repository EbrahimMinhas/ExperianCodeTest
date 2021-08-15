using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Experian.Services.WebRequest;
using Experian.Services.PhotoAlbum;
using Experian.Models.PhotoAlbum;

namespace Experian.UnitTest.Services
{
    [TestClass]
    public class PhotoAlbumServiceTests
    {
        private PhotoAlbumService _photoAlbumService;
        private Mock<IWebRequestService> _webRequestServiceMock;

        private List<Album> _albums;
        private List<Photo> _photos;

        [TestInitialize]
        public void Initialize()
        {
            _webRequestServiceMock = new Mock<IWebRequestService>();
            _webRequestServiceMock.Setup(x => x.GetRequestData<List<Album>>(It.IsAny<string>())).Returns(_albums);
            _webRequestServiceMock.Setup(x => x.GetRequestData<List<Photo>>(It.IsAny<string>())).Returns(_photos);
            _albums = new List<Album> { new Album { Id = 1, Title = "TestAlbum", UserId = 1 }, new Album { Id = 2, Title = "TestAlbum2", UserId = 2 } };
            _photos = new List<Photo> { new Photo { AlbumId = 1, Title = "TestPhoto" }, new Photo { AlbumId = 2, Title = "TestPhoto2" } };
            _photoAlbumService = new PhotoAlbumService(_webRequestServiceMock.Object);
        }

        [TestMethod]
        public void TestPhotoAlbumServiceGet()
        {
            //act
            List<Album> result = _photoAlbumService.Get();

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        [DataRow(1,1)]
        [DataRow(4, 0)]
        public void TestPhotoAlbumServiceGetById(int id, int expectdResultCount)
        {
            //act
            List<Album> result = _photoAlbumService.GetById(id);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, expectdResultCount);
        }
    }
}
