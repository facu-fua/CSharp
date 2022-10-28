namespace WebApplication1.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public Venta()
        {
            Id = 0;
            Comentarios = string.Empty;
            IdUsuario = 0;
        }

        public Venta(int apellido, string comentarios, int idUsuario)
        {
            Id = apellido;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }
    }
}
