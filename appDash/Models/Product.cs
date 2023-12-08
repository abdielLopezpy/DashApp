using System;
using System.ComponentModel.DataAnnotations;

namespace appDash.Models
{
    public class Product
    {
        // Genera un ID de producto único de forma aleatoria
        public int Id { get; set; } = GenerateRandomProductId();

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido.")]
        public required string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser mayor que cero.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El Precio debe ser mayor que cero.")]
        public decimal Price { get; set; }

        // Agregar el campo UserId para el usuario que crea el producto
        public required string UserId { get; set; }

        private static int GenerateRandomProductId()
        {
            // Genera un ID de forma aleatoria utilizando el reloj del sistema
            var random = new Random();
            return random.Next(1, int.MaxValue);
        }
    }
}
