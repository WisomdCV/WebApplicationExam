using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB08WILSONDCV.Models
{
    // Mapea esta clase a la tabla "clients" en la base de datos.
    [Table("clients")]
    public class Client
    {
        [Key] // Marca esta propiedad como la clave primaria.
        [Column("clientid")] // Mapea esta propiedad a la columna "clientid".
        public int ClientId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        // Propiedad de navegación: Un cliente puede tener muchas órdenes.
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}