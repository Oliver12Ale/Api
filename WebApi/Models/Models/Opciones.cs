using System;
using System.Collections.Generic;

namespace WebApi.Models.Models
{
    public partial class Opciones
    {
        public int IdOpcion { get; set; }
        public int IdPregunta { get; set; }
        public string Opcion { get; set; }
        public bool EsCorrecta { get; set; }
        public bool Activo { get; set; }

        public virtual Preguntas IdPreguntaNavigation { get; set; }
    }
}
