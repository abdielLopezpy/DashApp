using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appDash.Models
{
    public class Employee
    {
        [Key] // Esto marca el campo como clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esto configura la generación automática del valor
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Cargo es requerido.")]
        public string Position { get; set; }

        // Agregar otras propiedades relacionadas con los empleados según tus necesidades

        // Constructor vacío para Entity Framework
        public Employee() { }

        // Constructor para crear un nuevo empleado
        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }
    }
}
