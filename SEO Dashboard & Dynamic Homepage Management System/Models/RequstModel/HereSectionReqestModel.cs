namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel
{
    public class HereSectionReqestModel
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public string? publicId { get; set; }
    }
}
