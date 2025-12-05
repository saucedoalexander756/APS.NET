using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVete.Models
{
    [Table("cat_productos")]
    public class Producto
    {
        [Key]
        public int eCodProducto { get; set; }

        public string Nombre { get; set; }

        public string? iDescripcion { get; set; }

        public decimal iPrecio { get; set; }

        public int iStock { get; set; }

        public int? iCodEstatus { get; set; }
    }
}