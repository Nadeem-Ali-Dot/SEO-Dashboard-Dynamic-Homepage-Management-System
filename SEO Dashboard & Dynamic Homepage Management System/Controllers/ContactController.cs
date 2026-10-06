using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactInformation _Service;
        public ContactController(IContactInformation Service)
        {
            this._Service = Service;

        }
        [HttpGet]
        public async Task<IActionResult> GetConact()
        {
            var data = await _Service.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var data = await _Service.GetSingle(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create( ContactInformation obj )
        {
            var created = await _Service.Add(obj);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, ContactInformation obj)
        {
            var data = await _Service.Update(id, obj);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _Service.Delete(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
