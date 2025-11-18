using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB08WILSONDCV.Models
{
    [Table("orderdetails")]
    public class OrderDetail
    {
        [Key]
        [Column("orderdetailid")]
        public int OrderDetailId { get; set; }

        [Column("orderid")]
        public int OrderId { get; set; }

        [Column("productid")]
        public int ProductId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        // Propiedad de navegación: Cada detalle pertenece a una orden.
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } = null!;

        // Propiedad de navegación: Cada detalle tiene un producto.
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
    }
}