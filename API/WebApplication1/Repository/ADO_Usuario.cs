using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ADO_Usuario
    {
        public Usuario TraerUsuario(string nombreUsuario)
        {

            Usuario usuario = new Usuario();
            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @nombre";

                var parametro = new SqlParameter();
                parametro.ParameterName = "nombre";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nombreUsuario;
                cmd.Parameters.Add(parametro);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Password = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();
                }
                reader.Close();
                connection.Close();

            }
            return usuario;

        } 

        public string TraerNombre(int id)
        {
            string nombre;
            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT Nombre FROM Usuario WHERE Id = @id";
                var parametro = new SqlParameter();
                parametro.ParameterName = "id";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd.Parameters.Add(parametro);

                if ((string)cmd.ExecuteScalar() != null)
                {
                    nombre = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    nombre = "Error, usuario no encontrado!";
                }
                connection.Close();

            }
            return nombre;
            
        }

        public void ModificarUsuario(int id, string nombre, string apellido, string nombreUsuario, string password, string mail)
        {

            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "UPDATE Usuario SET Nombre=@nombre, Apellido=@apellido, NombreUsuario=@nameUser," +
                    " Contraseña = @contrasenia, Mail=@mail WHERE Id = @id";

                var parametro = new SqlParameter();
                parametro.ParameterName = "id";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                var parametro1 = new SqlParameter();
                parametro1.ParameterName = "nombre";
                parametro1.SqlDbType = SqlDbType.VarChar;
                parametro1.Value = nombre;

                var parametro2 = new SqlParameter();
                parametro2.ParameterName = "apellido";
                parametro2.SqlDbType = SqlDbType.VarChar;
                parametro2.Value = apellido;

                var parametro3 = new SqlParameter();
                parametro3.ParameterName = "nameUser";
                parametro3.SqlDbType = SqlDbType.VarChar;
                parametro3.Value = nombreUsuario;

                var parametro4 = new SqlParameter();
                parametro4.ParameterName = "contrasenia";
                parametro4.SqlDbType = SqlDbType.VarChar;
                parametro4.Value = password;

                var parametro5 = new SqlParameter();
                parametro5.ParameterName = "mail";
                parametro5.SqlDbType = SqlDbType.VarChar;
                parametro5.Value = mail;

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

        public void EliminarUsuario(int IdUsuario)
        {

            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "DELETE FROM Usuario WHERE Id = @id";

                var parametro = new SqlParameter();
                parametro.ParameterName = "id";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = IdUsuario;
                cmd.Parameters.Add(parametro);

                cmd.ExecuteNonQuery();


                connection.Close();
            }
        }

        public void CrearUsuario(string nombre, string apellido, string nombreUsuario, string password, string mail)
        {

            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) " +
                    "VALUES(@nombre,@apellido,@nameUser,@contrasenia,@mail)";

                var parametro = new SqlParameter();
                parametro.ParameterName = "nombre";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nombre;

                var parametro1 = new SqlParameter();
                parametro1.ParameterName = "apellido";
                parametro1.SqlDbType = SqlDbType.VarChar;
                parametro1.Value = apellido;

                var parametro2 = new SqlParameter();
                parametro2.ParameterName = "nameUser";
                parametro2.SqlDbType = SqlDbType.VarChar;
                parametro2.Value = nombreUsuario;

                var parametro3 = new SqlParameter();
                parametro3.ParameterName = "contrasenia";
                parametro3.SqlDbType = SqlDbType.VarChar;
                parametro3.Value = password;

                var parametro4 = new SqlParameter();
                parametro4.ParameterName = "mail";
                parametro4.SqlDbType = SqlDbType.VarChar;
                parametro4.Value = mail;

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
            string mensaje = string.Empty;
            int id = 0;
            string nombre = string.Empty;

            using (SqlConnection connection = new SqlConnection(Conexion.ConexionString()))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @user and Contraseña = @pass";

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
                  nombre = reader.GetValue(1).ToString();
                }

                if (id == 0)
                {
                    mensaje = "Ingreso fallido. Verifique el usuario o contraseña";
                }
                else
                {
                    mensaje = "Ingreso exitoso. Bienvenido " + nombre;
                }
                reader.Close();

                connection.Close();

            }
            return mensaje;

        }
    }

}
