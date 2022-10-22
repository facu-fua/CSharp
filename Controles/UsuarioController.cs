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
    internal class UsuarioController
    {/*
        public static Usuario Login(string Nombreusuario, string password)
        {
            var user = new Usuario();
            // Esto se debe hacer en cada controller para obtener los datos
            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "DESKTOP-HH6P1J3";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var cs = connectionBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @user and Contraseña = @pass";

                var parametro = new SqlParameter();
                parametro.ParameterName = "prenda";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = Nombreusuario;

                var parametro2 = new SqlParameter();
                parametro2.ParameterName = "pass";
                parametro2.SqlDbType = SqlDbType.VarChar;
                parametro2.Value = password;

                cmd.Parameters.Add(parametro);
                cmd.Parameters.Add(parametro2);

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
                if (user.Id == 0)
                {
                    Console.WriteLine("Usuario no existe");
                    Console.WriteLine("Id: " + 0);
                    Console.WriteLine("Nombre:");
                    Console.WriteLine("Apellido:");
                    Console.WriteLine("NombreUsuario:");
                    Console.WriteLine("Password:");
                    Console.WriteLine("Email:");
                }
                else
                {
                    Console.WriteLine("Log in realizado con exito!");
                    Console.WriteLine("Id: " + user.Id);
                    Console.WriteLine("Nombre: " + user.Nombre);
                    Console.WriteLine("Apellido: " + user.Apellido);
                    Console.WriteLine("NombreUsuario: " + user.NombreUsuario);
                    Console.WriteLine("Password: " + user.Password);
                    Console.WriteLine("Email: " + user.Mail);
                }

                reader.Close();

                connection.Close();
            }

        }

        public static Usuario TraerUsuario(string NombreUsuario)
        {
            Usuario user = new Usuario();

            // Esto se debe hacer en cada controller para obtener los datos
            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "DESKTOP-HH6P1J3";
            connectionBuilder.InitialCatalog = "SistemaGestion";
            connectionBuilder.IntegratedSecurity = true;

            var cs = connectionBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @user";

                var parametro = new SqlParameter();
                parametro.ParameterName = "prenda";
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

                // Esto se haria en el program como una especie de front
                Console.WriteLine("-------Usuario-------");
                Console.WriteLine("Id: " + user.Id);
                Console.WriteLine("Nombre: " + user.Nombre);
                Console.WriteLine("Apelldio: " + user.Apellido);
                Console.WriteLine("Nombre de Usuario: " + user.NombreUsuario);
                Console.WriteLine("Contraseña: " + user.Password);
                Console.WriteLine("Email: " + user.Mail);

                reader.Close();

                connection.Close();

            }

        }*/
    }
}
