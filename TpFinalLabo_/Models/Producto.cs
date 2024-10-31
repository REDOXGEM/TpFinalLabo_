using System.ComponentModel.DataAnnotations;

namespace TpFinalLabo_.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        [Display(Name = "Nombre Categoria")]
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [Display(Name = "Foto")]
        public string? Foto { get; set; }


        public List<Pedido>? pedidos { get; set; }
    }
}
