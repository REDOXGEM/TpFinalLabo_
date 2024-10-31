
using System.ComponentModel.DataAnnotations;

namespace TpFinalLabo_.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public int Dni { get; set; }
        public string? Email { get; set; }

        [Display(Name = "Foto")]
        public string? Foto { get; set; }

        public List<Pedido>? pedidos { get; set; }
    }
}
