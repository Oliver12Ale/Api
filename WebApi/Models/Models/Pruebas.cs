using System;
using System.Collections.Generic;

namespace WebApi.Models.Models
{
    public partial class Pruebas
    {
        public Pruebas()
        {
            DetallePrueba = new HashSet<DetallePrueba>();
        }

        public int IdPrueba { get; set; }
        public int Usuario { get; set; }
        public int IdTecnologia { get; set; }
        public int Nivel { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaTer { get; set; }
        public double Calificacion { get; set; }

        public virtual Tecnologias IdTecnologiaNavigation { get; set; }
        public virtual Niveles NivelNavigation { get; set; }
        public virtual Usuarios UsuarioNavigation { get; set; }
        public virtual ICollection<DetallePrueba> DetallePrueba { get; set; }
    }
}
