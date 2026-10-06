namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Entites
{
    public class SeoSettings: BaseEntity
    {
        public string PageName { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription        { get; set; }
        public string FocusKeywords { get; set; }
        public string CanonicalUrl { get; set; }
        public string RobotsTag { get; set; }
        public string OgTitle { get; set; }
        public string OgDescription { get; set; }
        public string OgImage { get; set; }
        public string TwitterTitle { get; set; }
        public string TwitterDescription { get; set; }
        public string TwitterImage { get; set; }

    }
}
