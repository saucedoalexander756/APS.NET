using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVete.Models
{
    [Table("cat_mascotas")]
    public class Mascota
    {
        [Key]
        public int eCodMascota { get; set; }

        public string Nombre { get; set; }

        public int eCodCliente { get; set; } 

        public DateTime dFechaNacimiento { get; set; }

        public string? iSexo { get; set; }

        public string? iColor { get; set; }

        
        public decimal iPeso { get; set; }

        public string? iAlergias { get; set; }

        public string? iObservaciones { get; set; }
    }
}