using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appDash.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esto configura el Id como una identidad
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Creación es requerido.")]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "El campo Estado es requerido.")]
        public bool IsActive { get; set; }

        // Relación con el cliente
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Lista de productos en el pedido
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }

    public class OrderProduct
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser mayor que cero.")]
        public int Quantity { get; set; }

        // Relación con el producto
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Relación con el pedido
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
