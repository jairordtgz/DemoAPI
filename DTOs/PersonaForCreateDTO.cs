using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.DTOs
{
    public class PersonaForCreateDTO
    {
        public required string Nombre {get; set; }
        public required string Apellido {get; set; }
        public DateTime Birthdate {get; set; }
    }
}