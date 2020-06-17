using System;
using System.Collections.Generic;

namespace WebApi.Models.Models
{
    public partial class Preguntas
    {
        public Preguntas()
        {
            Opciones = new HashSet<Opciones>();
        }

        public int IdPregunta { get; set; }
        public int IdTecnologia { get; set; }
        public string NombrePregunta { get; set; }
        public bool Activo { get; set; }

        public virtual Tecnologias IdTecnologiaNavigation { get; set; }
        public virtual ICollection<Opciones> Opciones { get; set; }
    }
}
