using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_entrega_proyecto_final.Modelos
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        public Usuario()
        {
            Id = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            NombreUsuario = string.Empty;
            Password = string.Empty;
            Mail = string.Empty;
        }

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string password, string mail)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Password = password;
            Mail = mail;
        }
    }
}
