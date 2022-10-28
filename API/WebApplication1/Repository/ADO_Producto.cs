using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ADO_Producto
    {
        public List<Producto> TraerProducto(int idUsuario)
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

                while (reader.Read())
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
                connection.Close();

            }
            return listaProductos;
        }
    }
}
