using System.Xml.Linq;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Entites
{
    public class Vehicles:BaseEntity
    {
       public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int SeatingCapacity { get; set; }
        public string Features { get; set; }
        public int DisplayOrder { get; set; }

        public string publicId { get; set; }


    }
}
