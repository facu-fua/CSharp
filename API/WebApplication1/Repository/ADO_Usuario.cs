using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ADO_Usuario
    {
        public Usuario TraerUsuario(string NombreUsuario)
        {
            Usuario user = new Usuario();

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "DESKTOP-HH6P1J3";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var cs = connectionBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = '@user'";

                var parametro = new SqlParameter();
                parametro.ParameterName = "user";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = NombreUsuario;

                cmd.Parameters.Add(parametro);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader.GetValue(0));
                    user.Nombre = reader.GetValue(1).ToString();
                    user.Apellido = reader.GetValue(2).ToString();
                    user.NombreUsuario = reader.GetValue(3).ToString();
                    user.Password = reader.GetValue(4).ToString();
                    user.Mail = reader.GetValue(5).ToString();
                }

                reader.Close();

                connection.Close();

            }
            return user;

        }

        public void ModificarUsuario(Usuario usuario)
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

                cmd.CommandText = "UPDATE Usuario SET Nombre='@nombre', Apellido='@apellido', NombreUsuario='@nameUser'," +
                    " Contraseña = '@contrasenia', Mail='@mail' WHERE Id = @id";

                var parametro = new SqlParameter();
                parametro.ParameterName = "id";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = usuario.Id;

                var parametro1 = new SqlParameter();
                parametro.ParameterName = "nombre";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = usuario.Nombre;

                var parametro2 = new SqlParameter();
                parametro.ParameterName = "apellido";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = usuario.Apellido;

                var parametro3 = new SqlParameter();
                parametro.ParameterName = "nameUser";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = usuario.NombreUsuario;

                var parametro4 = new SqlParameter();
                parametro.ParameterName = "contrasenia";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = usuario.Password;

                var parametro5 = new SqlParameter();
                parametro.ParameterName = "mail";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = usuario.Mail;

                cmd.Parameters.Add(parametro);
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);
                cmd.Parameters.Add(parametro4);
                cmd.Parameters.Add(parametro5);

                cmd.ExecuteNonQuery();

                connection.Close();

            }
        }
    }
    
}
