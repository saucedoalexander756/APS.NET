using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVete.Models
{
    [Table("seg_usuarios")]
    public class Usuario
    {
        [Key]
        public int eCodUsuario { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        // Almacena salt y hash en formato "salt:hash" (Base64)
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string? Role { get; set; }
    }
}