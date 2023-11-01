using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public long? DNI { get; set; }

    }
}
