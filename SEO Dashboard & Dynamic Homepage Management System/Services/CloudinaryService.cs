using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            var cloudName =
                configuration["CloudinarySettings:CloudName"];

            var apiKey =
                configuration["CloudinarySettings:ApiKey"];

            var apiSecret =
                configuration["CloudinarySettings:ApiSecret"];

            var account = new Account(
                cloudName,
                apiKey,
                apiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<(string Url, string PublicId)> UploadImageAsync(
            IFormFile file,
            string folder)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty.");
            }

            await using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),

                Folder = folder
            };

            var result = await _cloudinary.UploadAsync(uploadParams);

            if (result.Error != null)
            {
                throw new Exception(result.Error.Message);
            }

            return (
                result.SecureUrl.ToString(),
                result.PublicId
            );
        }

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            if (string.IsNullOrWhiteSpace(publicId))
                return false;

            var deleteParams = new DeletionParams(publicId);

            var result =
                await _cloudinary.DestroyAsync(deleteParams);

            return result.Result == "ok";
        }
    }
}