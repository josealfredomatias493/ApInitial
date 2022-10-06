using System;
using System.Collections.Generic;

namespace ApInitial.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Cita = new HashSet<Cita>();
        }

        public int PacCodigo { get; set; }
        public string PacNombre { get; set; } = null!;
        public string PacApellido { get; set; } = null!;
        public DateTime PacFechaNacimiento { get; set; }
        public decimal? PacTelefono { get; set; }
        public string? PacEmail { get; set; }
        public string PacDireccion { get; set; } = null!;
        public int? PacUsuario { get; set; }
        public string PacEstatus { get; set; } = null!;

        public virtual Usuario? PacUsuarioNavigation { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
