using System;
using System.Collections.Generic;

namespace WebApi.Models.Models
{
    public partial class NivelesUsuarios
    {
        public int IdNivelUsuario { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTecnologia { get; set; }
        public int? IdNivel { get; set; }

        public virtual Niveles IdNivelNavigation { get; set; }
        public virtual Tecnologias IdTecnologiaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
