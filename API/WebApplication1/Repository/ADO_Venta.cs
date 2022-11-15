using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ADO_Venta
    {
        public List<Venta> Ventas(int idUsuario)
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Venta WHERE IdUsuario = @idUser";

                var parametro = new SqlParameter();
                parametro.ParameterName = "idUser";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = idUsuario;

                cmd.Parameters.Add(parametro);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var venta = new Venta();
                    venta.Id = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));

                    ventas.Add(venta);
                }

                reader.Close();

                connection.Close();

            }
            return ventas;
        }

        public void CargarVenta(int id, List<ProductoVendido> productoVendidos)
        {
            int idVenta;
            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "INSER INTO Venta (Comentarios,idUsuario) VALUES (@comentarios,@idusuario); Select scope_identity();";

                var parametro = new SqlParameter();
                parametro.ParameterName = "comentarios";
                parametro.SqlDbType = SqlDbType.NVarChar;
                parametro.Value = "N''";

                var parametro1 = new SqlParameter();
                parametro1.ParameterName = "idusuario";
                parametro1.SqlDbType = SqlDbType.BigInt;
                parametro1.Value = id;

                cmd.Parameters.Add(parametro);
                cmd.Parameters.Add(parametro1);

                idVenta = Convert.ToInt32(cmd.ExecuteScalar());

                
                foreach (ProductoVendido producto in productoVendidos)
                {
                    SqlCommand cmd1 = connection.CreateCommand();
                    cmd1.CommandText = "INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta)  VALUES   (@Stock,@IdProducto,@IdVenta)";
                    cmd1.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto.Stock;
                    cmd1.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                    cmd1.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt)).Value = idVenta;
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandText = "UPDATE Producto SET Stock = Stock - @Stock WHERE idProducto = @IdProducto";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto.Stock;
                    cmd2.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                    cmd2.ExecuteNonQuery();
                }
                connection.Close();

            };
        }

        public void EliminarVenta(int id)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT Id,Stock,IdProducto,IdVenta FROM ProductoVendido WHERE IdVenta = @idVenta";
                cmd.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt)).Value = id;
                var reader2 = cmd.ExecuteReader();
                while (reader2.Read())
                {
                    SqlCommand cmd1 = connection.CreateCommand();
                    cmd1.CommandText = "UPDATE Producto SET Stock = Stock + @Stock WHERE idProducto = @IdProducto";
                    cmd1.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = Convert.ToInt32(reader2.GetValue(1).ToString());
                    cmd1.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = Convert.ToInt64(reader2.GetValue(2));
                    cmd1.ExecuteNonQuery();
                }
                reader2.Close();

                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "DELETE FROM ProductoVendido WHERE IdVenta = @id";
                var parametro = new SqlParameter();
                parametro.ParameterName = "id";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();

                SqlCommand cmd3 = connection.CreateCommand();
                cmd3.CommandText = "DELETE FROM Venta WHERE IdVenta = @idVenta";
                cmd3.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<ProductoVendidoDetalle> TraerProductosVenta()
        {
            var productosVendidos = new List<ProductoVendidoDetalle>();
            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT p.Descripciones, p.Costo, p.PrecioVenta, pv.Stock FROM ProductoVendido pv INNER JOIN Producto p on pv.IdProducto = p.Id";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var venta = new ProductoVendidoDetalle();
                    venta.Descripciones = reader.GetValue(0).ToString();
                    venta.Costo = Convert.ToInt32(reader.GetValue(1));
                    venta.PrecioVenta = Convert.ToInt32(reader.GetValue(2));
                    venta.Stock = Convert.ToInt32(reader.GetValue(3));
                    productosVendidos.Add(venta);

                }
                reader.Close();
                connection.Close();

            }
            return productosVendidos;
        }
    }
}
