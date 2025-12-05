using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVete.Models
{
    [Table("ret_consultas")]
    public class Consulta
    {
        [Key]
        public int eCodConsulta { get; set; }

        public int eCodMascota { get; set; }

        public DateTime dFechaConsulta { get; set; }

        public string? iSintomas { get; set; }

        public string? iDiagnostico { get; set; }

        public string? iTratamiento { get; set; }

        public string? iObservaciones { get; set; }

        public decimal iCosto { get; set; }
    }
}