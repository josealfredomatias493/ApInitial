using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApInitial.Models
{
    public partial class Usuarios
    {
        [Key]
        public int UserCodigo { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string UserNombre { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string UserPassword { get; set; }
        [Required]
        public string UserFechaCreacion { get; set; }
        [ForeignKey("Roles")]
        public int RlCodigo { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string UserEstatus { get; set; }
        public virtual Roles? Roles { get; set; }
        [NotMapped]
        public virtual ICollection<Doctores>? Doctores { get; set; }
        [NotMapped]
        public virtual ICollection<Pacientes>? Pacientes { get; set; }
    }
}
