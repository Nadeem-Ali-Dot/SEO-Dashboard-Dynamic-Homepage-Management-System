namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel
{
    public class VehiclesRequestmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public int SeatingCapacity { get; set; }
        public string Features { get; set; }
        public int DisplayOrder { get; set; }

        public string? publicId { get; set; }
    }
}
