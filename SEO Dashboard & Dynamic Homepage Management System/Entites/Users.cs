namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Entites
{
    public class Users
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
        public int CreatedAt { get; set; }


        


    }
}
