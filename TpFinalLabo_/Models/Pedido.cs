namespace TpFinalLabo_.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string? Calle { get; set; }
        public int Altura { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public int Idcliente { get; set; }
        public Cliente? cliente { get; set; }

        public int Idproducto { get; set; }
        public Producto? producto { get; set; }

        public DateTime Fecha { get; set; }

        public string? Estado { get; set; }

    }
}
