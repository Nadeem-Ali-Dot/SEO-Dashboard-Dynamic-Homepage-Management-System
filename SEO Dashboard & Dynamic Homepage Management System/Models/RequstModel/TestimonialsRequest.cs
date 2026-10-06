namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel
{
    public class TestimonialsRequest
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Review { get; set; }
        public string Rating { get; set; }
        public IFormFile? CustomerImage { get; set; }

        public string? publicId { get; set; }
    }
}
