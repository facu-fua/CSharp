using System.Data.SqlClient;
using System.Data;
using WebApplication1.Controllers;
using WebApplication1.Models;
using System.Data.Common;

namespace WebApplication1.Repository
{
    public class ADO_ProductoVenta
    {
        public List<ProductoVenta> TraerProductoVendido(int id)
        {
            //creo lista para productos vendidos
            List<ProductoVenta> vendidos = new List<ProductoVenta>();
            int idVenta = 1;
            ADO_Producto _productos;
            _productos = new ADO_Producto();

            SqlConnectionStringBuilder connectionBuilder1 = new SqlConnectionStringBuilder();
            connectionBuilder1.DataSource = "DESKTOP-HH6P1J3";
            connectionBuilder1.InitialCatalog = "SistemaGestion";
            connectionBuilder1.IntegratedSecurity = true;

            var cs1 = connectionBuilder1.ConnectionString;

            using (SqlConnection connection1 = new SqlConnection(cs1))
            {
                connection1.Open();

                SqlCommand cmd = connection1.CreateCommand();

                cmd.CommandText = "SELECT Id FROM Venta WHERE IdUsuario = @idUser";

                var parametro = new SqlParameter();
                parametro.ParameterName = "idUser";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;
                cmd.Parameters.Add(parametro);

                idVenta = Convert.ToInt32(cmd.ExecuteScalar());

            }



            //trae una lista de productos del usuario
            List<Producto> productoUsuario = _productos.TraerProducto(id);

            //productoUsuario.ForEach(Producto<>)
            foreach (Producto product in productoUsuario)
            {
                using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
                {
                    connection.Open();


                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT * FROM ProductoVendido WHERE IdProducto = @idProducto and IdVenta = @idVenta";

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idVenta";
                    parametro.SqlDbType = SqlDbType.BigInt;
                    parametro.Value = idVenta;

                    var parametro2 = new SqlParameter();
                    parametro2.ParameterName = "idProducto";
                    parametro2.SqlDbType = SqlDbType.BigInt;
                    parametro2.Value = product.Id;

                    cmd.Parameters.Add(parametro);
                    cmd.Parameters.Add(parametro2);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
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

        public List<ProductoVenta> TraerProductosVendidos()
        {
            List<ProductoVenta> productosVendidos = new List<ProductoVenta>();

            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM ProductoVendido";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   
                        var producto = new ProductoVenta();
                        producto.Id = Convert.ToInt32(reader.GetValue(0));
                        producto.Stock = Convert.ToInt32(reader.GetValue(1));
                        producto.IdProducto = Convert.ToInt32(reader.GetValue(2));
                        producto.IdVenta = Convert.ToInt32(reader.GetValue(3));

                        productosVendidos.Add(producto);
                }

                reader.Close();

                connection.Close();
            }

            return productosVendidos;
        }

    }
}