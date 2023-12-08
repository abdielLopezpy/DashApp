using System;
using System.ComponentModel.DataAnnotations;

namespace appDash.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Email es requerido.")]
        [EmailAddress(ErrorMessage = "El campo Email no es una dirección de correo electrónico válida.")]
        public string Email { get; set; }

    }
}
