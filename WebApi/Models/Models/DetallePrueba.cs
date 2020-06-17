using System;
using System.Collections.Generic;

namespace WebApi.Models.Models
{
    public partial class DetallePrueba
    {
        public int IdDetallePrueba { get; set; }
        public int? IdPrueba { get; set; }
        public string Pregunta { get; set; }
        public int? OpcionUsuario { get; set; }
        public int? OpcionCorrecta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public bool? Correcta { get; set; }

        public virtual Pruebas IdPruebaNavigation { get; set; }
    }
}
