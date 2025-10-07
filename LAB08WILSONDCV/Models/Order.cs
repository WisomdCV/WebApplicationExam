using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB08WILSONDCV.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("orderid")]
        public int OrderId { get; set; }

        [Column("clientid")]
        public int ClientId { get; set; }

        [Column("orderdate")]
        public DateTime OrderDate { get; set; }

        // Propiedad de navegación: Cada orden pertenece a un cliente.
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        // Propiedad de navegación: Cada orden tiene muchos detalles.
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}