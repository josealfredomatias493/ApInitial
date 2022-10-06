using System;
using System.Collections.Generic;

namespace ApInitial.Models
{
    public partial class Horario
    {
        public Horario()
        {
            HdCodigoDoctors = new HashSet<Doctore>();
        }

        public int HrCodigo { get; set; }
        public DateTime HrIncio { get; set; }
        public DateTime HrFinal { get; set; }
        public string HrEstatus { get; set; } = null!;

        public virtual ICollection<Doctore> HdCodigoDoctors { get; set; }
    }
}
