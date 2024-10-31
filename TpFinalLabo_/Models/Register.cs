using System.ComponentModel.DataAnnotations;

namespace TpFinalLabo_.Models
{
    public class Register
    {
        [Required(ErrorMessage = "El Email es obligatorio")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        public string ConfirContrasena { get; set; }


    }
}
