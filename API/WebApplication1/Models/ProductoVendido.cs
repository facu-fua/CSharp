namespace WebApplication1.Models
{
    public class ProductoVendido
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
        //modificar atributos, ej: costoFinal = stock*precioVenta, quitar idProducto
        public ProductoVendido()
        {
            Nombre = string.Empty;
            Id = 0;
            Stock = 0;
            IdProducto = 0;
            IdVenta = 0;
        }

        public ProductoVendido(string nombre, int id, int stock, int idProducto, int idVenta)
        {
            Nombre = nombre;
            Id = id;
            Stock = stock;
            IdProducto = idProducto;
            IdVenta = idVenta;
        }
    }
}
