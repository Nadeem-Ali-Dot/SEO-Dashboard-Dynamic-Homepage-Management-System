using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel
{
    public class AboutRequestmodel:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? ImageUrl { get; set; } 

        public string publicId { get; set; }
    }
}
