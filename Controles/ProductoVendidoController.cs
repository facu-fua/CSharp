using _1er_entrega_proyecto_final.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_entrega_proyecto_final.Controles
{
    internal class ProductoVendidoController
    {
        
        public static List<ProductoVenta> TraerProductoVendido(int id)
        {
            //creo lista para productos vendidos
            List<ProductoVenta> vendidos = new List<ProductoVenta>();

            //trae una lista de productos del usuario
            List<Producto> productoUsuario = ProductoController.TraerProducto(id);

            //productoUsuario.ForEach(Producto<>)
            foreach (Producto product in productoUsuario)
            {
                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = "DESKTOP-HH6P1J3";
                connectionBuilder.InitialCatalog = "SistemaGestion";
                connectionBuilder.IntegratedSecurity = true;

                var cs = connectionBuilder.ConnectionString;

                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM ProductoVendido WHERE IdProducto = @idProduct";

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idProduct";
                    parametro.SqlDbType = SqlDbType.BigInt;
                    parametro.Value = product.Id;
                    cmd.Parameters.Add(parametro);

                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        ProductoVenta producto = new ProductoVenta();
                        producto.Id = Convert.ToInt32(reader.GetValue(0));
                        producto.Stock = Convert.ToInt32(reader.GetValue(1));
                        producto.IdProducto = Convert.ToInt32(reader.GetValue(2));
                        producto.IdVenta = Convert.ToInt32(reader.GetValue(3));

                        vendidos.Add(producto);
                    }
                    reader.Close();

                    connection.Close();

                }
            }
            return vendidos;
        }
    }
}
