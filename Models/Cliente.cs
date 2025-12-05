using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 

namespace ApiVete.Models
{
 
    [Table("cat_clientes")]
    public class Cliente
    {
        [Key] 
        public int eCodCliente { get; set; }

        public string Nombre { get; set; }

        public string iApellido { get; set; }

   
        public string? iTelefono { get; set; }

        public string? iEmail { get; set; }

        public string? iDireccion { get; set; }

        public int? iCodEstatus { get; set; }
    }
}