using System;
using System.Collections.Generic;

namespace ApInitial.Models
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int RlCodigo { get; set; }
        public string RlNombre { get; set; } = null!;
        public string RlEstatus { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
