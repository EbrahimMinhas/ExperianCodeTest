using System.Collections.Generic;
using Experian.Models.PhotoAlbum;

namespace Experian.Services.PhotoAlbum
{
    public interface IPhotoAlbumService
    {
        List<Album> Get();
        List<Album> GetById(int id);
    }
}
