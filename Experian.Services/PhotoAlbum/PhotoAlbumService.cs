using Experian.Models.PhotoAlbum;
using Experian.Services.WebRequest;
using System.Collections.Generic;

namespace Experian.Services.PhotoAlbum
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly IWebRequestService _webRequestService;

        private readonly string _photoUrl = "http://jsonplaceholder.typicode.com/photos";
        private readonly string _albumUrl = "http://jsonplaceholder.typicode.com/albums";

        public PhotoAlbumService(IWebRequestService webRequestService)
        {
            _webRequestService = webRequestService;
        }

        public List<Album> Get()
        {
            List<Photo> photos = _webRequestService.GetRequestData<List<Photo>>(_photoUrl);
            List<Album> albums = _webRequestService.GetRequestData<List<Album>>(_albumUrl);

            return MapData(albums,photos);
        }

        public List<Album> GetById(int id)
        {
            List<Album> result = Get();

            return result.FindAll(x => x.Id == id);
        }

        private List<Album> MapData(List<Album> albums, List<Photo> photos)
        {
            foreach(Album album in albums)
            {
                album.Photos = photos.FindAll(x => x.AlbumId == album.Id);
            }

            return albums;
        }
    }
}
