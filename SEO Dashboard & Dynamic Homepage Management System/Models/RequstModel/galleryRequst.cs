namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel
{
    public class galleryRequst
    {
        public int Id
        {
            get; set;
        }
        public IFormFile? ImageUrl
        {
            get; set;
        }
        public string AltText { get; set; }
        public int DisplayOrder { get; set; }
        public string? publicId { get; set; }
    }
}
