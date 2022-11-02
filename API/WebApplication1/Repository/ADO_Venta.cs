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

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "DESKTOP-HH6P1J3";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var cs = connectionBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
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

        public void CargarVenta(int id)
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

                cmd.CommandText = "INSER INTO Venta (Comentarios,idUsuario) VALUES ('@comentarios',@idusuario)";

                var parametro = new SqlParameter();
                parametro.ParameterName = "comentarios";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = "N''";

                var parametro1 = new SqlParameter();
                parametro.ParameterName = "idusuario";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd.Parameters.Add(parametro);
                cmd.Parameters.Add(parametro1);

                cmd.ExecuteNonQuery();

                connection.Close();

            }
        }

    }
}
