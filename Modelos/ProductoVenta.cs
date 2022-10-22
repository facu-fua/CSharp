using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_entrega_proyecto_final.Modelos
{
    internal class ProductoVenta
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public ProductoVenta()
        {
            Id = 0;
            Stock = 0;
            IdProducto = 0;
            IdVenta = 0;
        }

        public ProductoVenta(int id, int stock, int idProducto, int idVenta)
        {
            Id = id;
            Stock = stock;
            IdProducto = idProducto;
            IdVenta = idVenta;
        }
    }
}
