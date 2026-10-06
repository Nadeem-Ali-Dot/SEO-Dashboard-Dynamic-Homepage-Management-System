namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Entites
{
    public class Gallery:BaseEntity
    {
        public string ImageUrl
        {
            get; set;
        }
        public string AltText { get; set; }
        public int DisplayOrder { get; set; }
        public string publicId { get; set; }




    }
}
