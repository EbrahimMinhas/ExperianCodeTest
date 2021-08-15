using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Experian.Services.PhotoAlbum;
using Experian.Models.PhotoAlbum ;
using System;

namespace ExperianCodeTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoAlbumController : ControllerBase
    {
        IPhotoAlbumService _photoAlbumService;

        public PhotoAlbumController(IPhotoAlbumService photoAlbumService)
        {
            _photoAlbumService = photoAlbumService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Album> result = _photoAlbumService.Get();

                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch(Exception)
            {
                return BadRequest("Something Went Wrong.");
            }
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                IEnumerable<Album> result = _photoAlbumService.GetById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Something Went Wrong.");
            }
        }
    }
}
