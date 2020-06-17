using System;
using System.Collections.Generic;

namespace WebApi.Models.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            NivelesUsuarios = new HashSet<NivelesUsuarios>();
            Pruebas = new HashSet<Pruebas>();
        }

        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<NivelesUsuarios> NivelesUsuarios { get; set; }
        public virtual ICollection<Pruebas> Pruebas { get; set; }
    }
}
