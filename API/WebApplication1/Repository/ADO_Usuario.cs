using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ADO_Usuario
    {
        public Usuario TraerUsuario(string nombreUsuario)
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
                parametro.Value = nombreUsuario;

                cmd.Parameters.Add(parametro);

                var reader = cmd.ExecuteReader();
                while (reader.Read()) // aca falta algo porque no esta guardando los datos
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

        } //no trae nada

        public string TraerNombre(string user)
        {
            string nombre;

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "DESKTOP-HH6P1J3";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var cs = connectionBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT Nombre FROM Usuario WHERE NombreUsuario = '@user'";

                var parametro = new SqlParameter();
                parametro.ParameterName = "user";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = user;

                cmd.Parameters.Add(parametro);

                if(cmd.ExecuteScalar() != null)
                {
                    nombre = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    nombre = null;
                }
                
                
                connection.Close();

            }
            if (string.IsNullOrEmpty(nombre))
            {
                string mensaje = "El usuario no existe";
                return mensaje;

            }else
            {
                return nombre;
            }
            
        } //error con el executescalar

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

        public void EliminarUsuario(string nombreUsuario)
        {
            string mensaje;
            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "DESKTOP-HH6P1J3";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var cs = connectionBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "DELETE FROM Usuario WHERE NombreUsuario='@user'";

                var parametro = new SqlParameter();
                parametro.ParameterName = "user";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nombreUsuario;
                cmd.Parameters.Add(parametro);

                cmd.ExecuteNonQuery();


                connection.Close();
            }
        } //lo mismo que el eliminarproducto

        public void CrearUsuario(string nombre, string apellido, string nombreUsuario, string password, string mail)//agregar al controller con mensaje
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

                cmd.CommandText = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) " +
                    "VALUES('@nombre','@apellido','@nameUser','@contrasenia','@mail')";

                var parametro = new SqlParameter();
                parametro.ParameterName = "nombre";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nombre;

                var parametro1 = new SqlParameter();
                parametro.ParameterName = "apellido";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = apellido;

                var parametro2 = new SqlParameter();
                parametro.ParameterName = "nameUser";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nombreUsuario;

                var parametro3 = new SqlParameter();
                parametro.ParameterName = "contrasenia";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = password;

                var parametro4 = new SqlParameter();
                parametro.ParameterName = "mail";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = mail;

                cmd.Parameters.Add(parametro);
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);
                cmd.Parameters.Add(parametro4);

                cmd.ExecuteNonQuery();

                connection.Close();

            }
        }

        public string Login(string nombreUsuario, string password)
        {
            string mensaje;
            int id;

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "DESKTOP-HH6P1J3";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var cs = connectionBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = '@user' and Contraseña = '@pass'";

                var parametro = new SqlParameter();
                parametro.ParameterName = "user";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nombreUsuario;

                var parametro1 = new SqlParameter();
                parametro1.ParameterName = "pass";
                parametro1.SqlDbType = SqlDbType.VarChar;
                parametro1.SqlValue = password;

                cmd.Parameters.Add(parametro);
                cmd.Parameters.Add(parametro1);

                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                  id = Convert.ToInt32(reader.GetValue(0));
                }

                reader.Close();

                connection.Close();

                if (id == 0)
                {
                    mensaje = "Ingreso fallido. Verifique el usuario o contraseña";
                }
                else
                {
                    mensaje = "Ingreso exitoso. Bienvenido" + reader.GetValue(1).ToString();
                }

            }
            return mensaje;

        }
    }

    
    
}
