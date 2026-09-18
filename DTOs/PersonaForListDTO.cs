using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.DTOs
{
    public class PersonaForListDTO
    {

        public required string Nombre {get; set;}
        public required string Apellido {get; set; }
        public int Edad {get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}"; 
    }
}