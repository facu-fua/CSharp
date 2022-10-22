using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_entrega_proyecto_final.Modelos
{
    internal class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public Venta()
        {
            Id = 0;
            Comentarios = string.Empty;
            IdUsuario = 0;
        }

        public Venta(int apellido, string comentarios, int idUsuario)
        {
            Id = apellido;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }
    }
    
}
