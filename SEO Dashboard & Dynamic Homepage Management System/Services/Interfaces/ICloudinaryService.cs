namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<(string Url, string PublicId)> UploadImageAsync(
            IFormFile file,
            string folder);

        Task<bool> DeleteImageAsync(string publicId);
    }
}
