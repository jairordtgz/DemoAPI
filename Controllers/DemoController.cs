using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using SQLitePCL;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello world"); 
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"El id proporcionado es: {id}"); 
        }


        
    }
}