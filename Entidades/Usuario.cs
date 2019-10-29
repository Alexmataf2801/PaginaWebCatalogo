using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string CorreoElectronico { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Genero { get; set; }
        public string UsuarioCreacion { get; set; }
        public bool Temporal { get; set; }
        public int IdPerfil { get; set; }
        public bool Estado { get; set; }
        public bool RespuestaResponse { get; set; }
    }
}
