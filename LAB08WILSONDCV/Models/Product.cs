using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB08WILSONDCV.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("productid")]
        public int ProductId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        // La descripción puede ser nula, por eso el '?'
        [Column("description")]
        public string? Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        // Propiedad de navegación: Un producto puede estar en muchos detalles de orden.
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}