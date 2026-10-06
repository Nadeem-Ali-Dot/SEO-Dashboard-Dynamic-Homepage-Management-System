using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGallery galleryService;
        public GalleryController(IGallery _galleryService)
        { this.galleryService = _galleryService;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetGallery()
        {
            var gallery = await galleryService.GetAll();
            return Ok(gallery);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGalleryById(int id)
        {
            var gallery = await galleryService.GetSingle(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return Ok(gallery);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGallery( [FromForm] galleryRequst gallery)
        {
            var createdGallery = await galleryService.Add(gallery);
            return Ok(createdGallery);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGallery(int id, galleryRequst gallery)
        {
            var updatedGallery = await galleryService.Update(id, gallery);
            if (updatedGallery == null)
            {
                return NotFound();
            }
            return Ok(updatedGallery);
        }
        [HttpDelete("{id}")]
        public async Task< IActionResult> DeleteGallery(int id)
        {
            var deletedGallery = await galleryService.Delete(id);
            if (deletedGallery == null)
            {
                return NotFound();
            }
            return Ok(deletedGallery);
        }
    }
}
