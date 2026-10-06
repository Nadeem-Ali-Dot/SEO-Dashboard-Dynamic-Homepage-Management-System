using System.Net;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Models
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public HttpStatusCode statusCode {  get; set; }
        public List<string> ErrorMessages { get; set; }
        
    }
}
