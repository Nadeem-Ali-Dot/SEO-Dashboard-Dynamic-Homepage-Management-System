using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Entites;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Models.RequstModel;
using SEO_Dashboard___Dynamic_Homepage_Management_System.Services.Interfaces;

namespace SEO_Dashboard___Dynamic_Homepage_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly Iaboutsection _Service;
        public AboutController(Iaboutsection Service)
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
        public async Task<IActionResult> Create([FromForm] AboutRequestmodel obj)
        {
            var created = await _Service.Add(obj);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, AboutSection obj)
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
