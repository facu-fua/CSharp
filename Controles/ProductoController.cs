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
    internal class ProductoController
    {/*
        public static List<Producto> TraerProducto(int idUsuario)
        {
            var listaProductos = new List<Producto>();

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "DESKTOP-HH6P1J3";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var cs = connectionBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Producto WHERE IdUsuario = @idUser";

                var parametro = new SqlParameter();
                parametro.ParameterName = "idUser";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = idUsuario;
                cmd.Parameters.Add(parametro);

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(reader.GetValue(0));
                    producto.Descripciones = reader.GetValue(1).ToString();
                    producto.Costo = Convert.ToDouble(reader.GetValue(2));
                    producto.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    producto.Stock = Convert.ToInt32(reader.GetValue(4));
                    producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaProductos.Add(producto);

                }
                Console.WriteLine("-------PRODUCTOS-------");
                foreach (Producto producto in listaProductos)
                {
                    Console.WriteLine("Id: " + producto.Id);
                    Console.WriteLine("Descripcion: " + producto.Descripciones);
                    Console.WriteLine("Costo: " + producto.Costo);
                    Console.WriteLine("Precio de venta: " + producto.PrecioVenta);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Id del Usuario: " + producto.IdUsuario);
                    Console.WriteLine("------------------------------------- ");
                }

                connection.Close();

            }
        }*/
    }
}
