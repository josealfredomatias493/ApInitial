using System;
using System.Collections.Generic;

namespace ApInitial.Models
{
    public partial class Cita
    {
        public int CtCodigo { get; set; }
        public int? CtPaciente { get; set; }
        public string CtDescripcion { get; set; } = null!;
        public int? CtDoctorAsignado { get; set; }
        public string CtEstatus { get; set; } = null!;

        public virtual Doctore? CtDoctorAsignadoNavigation { get; set; }
        public virtual Paciente? CtPacienteNavigation { get; set; }
    }
}
