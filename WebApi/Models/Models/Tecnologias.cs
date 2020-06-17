using System;
using System.Collections.Generic;

namespace WebApi.Models.Models
{
    public partial class Tecnologias
    {
        public Tecnologias()
        {
            NivelesUsuarios = new HashSet<NivelesUsuarios>();
            Preguntas = new HashSet<Preguntas>();
            Pruebas = new HashSet<Pruebas>();
        }

        public int IdTecnologia { get; set; }
        public string NombreTec { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public bool TecActiva { get; set; }

        public virtual ICollection<NivelesUsuarios> NivelesUsuarios { get; set; }
        public virtual ICollection<Preguntas> Preguntas { get; set; }
        public virtual ICollection<Pruebas> Pruebas { get; set; }
    }
}
