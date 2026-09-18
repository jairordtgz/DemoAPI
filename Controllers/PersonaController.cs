using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Data;
using DemoAPI.DTOs;
using DemoAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonaController(DataContext context)
        {
            _context = context; 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var persona = await _context.Personas.FindAsync(id); 
            if (persona == null)
            { 
                return NotFound($"La persona con el id {id} no fue encontrada"); 
            }
            var PersonaListDTO = new PersonaForListDTO()
                {
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    Edad = persona.Edad,

                };
            return Ok(PersonaListDTO); 
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var personas = await _context.Personas.ToListAsync(); 
            return Ok(personas); 
        }

        [HttpGet()]
       private List<Persona> GetPersonas()
        {
            List<Persona> personas = new List<Persona>()
            {
                new Persona() {Id = 1, Nombre = "Juan", Apellido = "Perez"},
                new Persona() {Id = 2, Nombre = "Maria", Apellido = "Gomez"},
                new Persona() {Id = 3, Nombre = "Pedro", Apellido = "Gonzalez"},
                new Persona() {Id = 4, Nombre = "Luis", Apellido = "Rodriguez"},
                new Persona() {Id = 5, Nombre = "Ana", Apellido = "Lopez"},

            }; 
            return personas;  
        } 

        [HttpPost]
        public async Task<IActionResult> Post(PersonaForCreateDTO personaDTO)
        {
            try
            {
                var persona = new Persona()
                {
                    Nombre = personaDTO.Nombre,
                    Apellido = personaDTO.Apellido,
                    BirthDate = personaDTO.Birthdate,
                    Active = true,
                    CreatedDate = DateTime.Now
                }; 
                _context.Personas.Add(persona); 
                await _context.SaveChangesAsync(); 
                return Ok(persona); 
            } 
            catch(Exception e)
            {
                return BadRequest(e.Message); 
            }
            
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest("Los ids no coinciden"); 
 
            }
            var personaDB = await _context.Personas.FindAsync(id); 
            if (personaDB == null)
            {
                return NotFound($"La persona con el id {id} no fue encontrada"); 

            }
            personaDB.Nombre = persona.Nombre; 
            personaDB.Apellido = persona.Apellido; 
            // personaDB.Edad = persona.Edad;
            await _context.SaveChangesAsync(); 
            return Ok(personaDB);  

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id); 
            if (persona == null)
            {
                return NotFound($"La persona con id {id} no fue encontrada"); 

            }

            _context.Personas.Remove(persona); 
            await _context.SaveChangesAsync(); 
            return Ok(persona); 


        }


        
    }

    
}