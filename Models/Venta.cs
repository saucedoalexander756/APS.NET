using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVete.Models
{
    [Table("cat_ventas")]
    public class Venta
    {
        [Key]
        public int eCodVenta { get; set; }

        public int eCodCliente { get; set; }

        public int eCodProducto { get; set; }

        public int iCantidad { get; set; }

        public decimal iPrecioUnitario { get; set; }

        public decimal iTotal { get; set; }

        public DateTime dFechaVenta { get; set; }
    }
}