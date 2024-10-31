using System.ComponentModel.DataAnnotations;

namespace TpFinalLabo_.Models
{
    public class Login
    {
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Contrasena { get; set; }
        public bool RememberMe { get; set; }
    }
}
