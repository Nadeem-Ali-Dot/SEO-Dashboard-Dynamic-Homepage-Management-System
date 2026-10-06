using Microsoft.EntityFrameworkCore;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<HeroSection> heroSections { get; set; }
        public DbSet<AboutSection> aboutSections { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<ContactInformation> contactInformation { get; set; }
        public DbSet<Gallery> galleries { get; set; }
        public DbSet<SeoSettings> seoSettings { get; set; }
        public DbSet<Occasions> occasions { get; set; }
        public DbSet<Schemas> schemas { get; set; }
        public DbSet<Testimonials> testimonials { get; set; }
        public DbSet<Vehicles> vehicles { get; set; }

       
        
    }
}
