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

        public void CrearProducto(Producto producto)
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

                cmd.CommandText = "INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) VALUES" +
                    "('@descripcion',@costo,@precio,@stock,@idusuario)";

                var parametro = new SqlParameter();
                parametro.ParameterName = "descripcion";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = producto.Descripciones;
                cmd.Parameters.Add(parametro);

                var parametro1 = new SqlParameter();
                parametro.ParameterName = "costo";
                parametro.SqlDbType = SqlDbType.Money;
                parametro.Value = producto.Costo;
                cmd.Parameters.Add(parametro1);

                var parametro2 = new SqlParameter();
                parametro.ParameterName = "precio";
                parametro.SqlDbType = SqlDbType.Money;
                parametro.Value = producto.PrecioVenta;
                cmd.Parameters.Add(parametro2);

                var parametro3 = new SqlParameter();
                parametro.ParameterName = "stock";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Value = producto.Stock;
                cmd.Parameters.Add(parametro3);

                var parametro4 = new SqlParameter();
                parametro.ParameterName = "idusuario";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = producto.IdUsuario;
                cmd.Parameters.Add(parametro4);

                cmd.ExecuteNonQuery();


                connection.Close();

            }

        }

        public void ModificarProducto(Producto producto)
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

                cmd.CommandText = "UPDATE Producto SET Descripciones='@descripcion', Costo=@costo, PrecioVenta=@precio," +
                    " Stock = @stock, IdUsuario=@idusuario WHERE Id = @id";

                var parametro = new SqlParameter();
                parametro.ParameterName = "descripcion";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = producto.Descripciones;
                cmd.Parameters.Add(parametro);

                var parametro1 = new SqlParameter();
                parametro.ParameterName = "costo";
                parametro.SqlDbType = SqlDbType.Money;
                parametro.Value = producto.Costo;
                cmd.Parameters.Add(parametro1);

                var parametro2 = new SqlParameter();
                parametro.ParameterName = "precio";
                parametro.SqlDbType = SqlDbType.Money;
                parametro.Value = producto.PrecioVenta;
                cmd.Parameters.Add(parametro2);

                var parametro3 = new SqlParameter();
                parametro.ParameterName = "stock";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Value = producto.Stock;
                cmd.Parameters.Add(parametro3);

                var parametro4 = new SqlParameter();
                parametro.ParameterName = "idusuario";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = producto.IdUsuario;
                cmd.Parameters.Add(parametro4);

                var parametro5 = new SqlParameter();
                parametro.ParameterName = "id";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = producto.Id;
                cmd.Parameters.Add(parametro5);

                cmd.ExecuteNonQuery();


                connection.Close();
            }
        }

        public void EliminarProducto(int idProducto)
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

                cmd.CommandText = "DELETE FROM Producto WHERE Id=@id";

                var parametro = new SqlParameter();
                parametro.ParameterName = "id";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = idProducto;
                cmd.Parameters.Add(parametro);

                cmd.ExecuteNonQuery();


                connection.Close();
            }
        }

    }
 
}
