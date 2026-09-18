using System.Net;
using Microsoft.AspNetCore.Mvc; 
namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello world"); 
            
        }
    }
}