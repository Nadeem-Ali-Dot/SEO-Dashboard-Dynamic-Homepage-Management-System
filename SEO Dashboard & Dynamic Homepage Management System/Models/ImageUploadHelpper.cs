using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Models
{
    public class ImageUploadHelpper
    {
        private readonly ICloudinaryService _cloudinaryService;

        public ImageUploadHelpper(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;

        }
    }
}
