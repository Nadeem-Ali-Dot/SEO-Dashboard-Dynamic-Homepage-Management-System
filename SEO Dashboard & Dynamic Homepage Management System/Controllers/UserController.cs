using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Data;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _service;
        public UserController(IUser _service)
        { this._service = _service;

        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetSingle(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(Users user)
        {
           var userresponse= await _service.Add(user);
          
            return Ok(userresponse);
        }
    }
}
