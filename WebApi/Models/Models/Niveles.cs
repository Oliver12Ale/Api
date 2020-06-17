using System;
using System.Collections.Generic;

namespace WebApi.Models.Models
{
    public partial class Niveles
    {
        public Niveles()
        {
            NivelesUsuarios = new HashSet<NivelesUsuarios>();
            Pruebas = new HashSet<Pruebas>();
        }

        public int IdNivel { get; set; }
        public string Nivel { get; set; }
        public int CalificacionMin { get; set; }
        public int CalificacionMax { get; set; }

        public virtual ICollection<NivelesUsuarios> NivelesUsuarios { get; set; }
        public virtual ICollection<Pruebas> Pruebas { get; set; }
    }
}
