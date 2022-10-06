using System;
using System.Collections.Generic;

namespace ApInitial.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Doctores = new HashSet<Doctore>();
            Pacientes = new HashSet<Paciente>();
        }

        public int UserCodigo { get; set; }
        public string UserNombre { get; set; } = null!;
        public string UserContraseña { get; set; } = null!;
        public int? UserRol { get; set; }
        public string UserEstatus { get; set; } = null!;

        public virtual Role? UserRolNavigation { get; set; }
        public virtual ICollection<Doctore> Doctores { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
