using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public required string Nombre {get; set;}
        public required string Apellido {get; set; }
        // public int Edad {get; set; }
        public bool Active {get; set; }
        public DateTime CreatedDate {get; set; }
        public DateTime BirthDate {get; set; }
        public int Edad => DateTime.Now.Year - BirthDate.Year; 
    
    }
}