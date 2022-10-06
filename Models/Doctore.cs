using System;
using System.Collections.Generic;

namespace ApInitial.Models
{
    public partial class Doctore
    {
        public Doctore()
        {
            Cita = new HashSet<Cita>();
            HdCodigoHorarios = new HashSet<Horario>();
        }

        public int DocCodigo { get; set; }
        public string DocNombre { get; set; } = null!;
        public string DocApellido { get; set; } = null!;
        public decimal? DocTelefono { get; set; }
        public string? DocEmail { get; set; }
        public int? DocUsuario { get; set; }
        public string DocEspecialidades { get; set; } = null!;
        public string DocEstatus { get; set; } = null!;

        public virtual Usuario? DocUsuarioNavigation { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }

        public virtual ICollection<Horario> HdCodigoHorarios { get; set; }
    }
}
