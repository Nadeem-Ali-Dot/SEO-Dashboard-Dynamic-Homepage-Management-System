namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Entites
{
    public class Testimonials:BaseEntity
    {
        public string CustomerName { get; set; }
        public string Review { get; set; }
        public string Rating { get; set; }
        public string CustomerImage { get; set; }

        public string publicId { get; set; }



    }
}
