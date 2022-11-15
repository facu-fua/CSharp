namespace WebApplication1.Models
{
    public class ProductoVendidoDetalle
    {
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }

        public ProductoVendidoDetalle()
        {
            Descripciones = string.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
        }

        public ProductoVendidoDetalle(string descripciones, double costo, double precioVenta, int stock)
        {
            Descripciones = descripciones;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
        }
    }
}
