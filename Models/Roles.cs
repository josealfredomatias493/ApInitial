using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApInitial.Models
{
    public partial class Roles
    {
        [Key]
        public int RlCodigo { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string RlNombre { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string RlEstatus { get; set; }
        public virtual ICollection<Usuarios>? Usuarios { get; set; }
    }
}
