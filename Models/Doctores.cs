using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApInitial.Models
{
    public partial class Doctores
    {
        [Key]
        public int DocCodigo { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string DocNombre { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string DocApellido { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? DocTelefono { get; set; }
        [EmailAddress,Column(TypeName = "varchar(200)")]
        public string? DocEmail { get; set; }
        [ForeignKey("Usuario")]
        public int UserCodigo { get; set; }
        [Required]
        public DateTime DocHorarioInicial { get; set; }
        [Required]
        public DateTime DocHorarioFinal { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string DocEspecialidades { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string DocEstatus { get; set; }
        [NotMapped]
        public virtual Usuarios? Usuarios { get; set; }
        public virtual ICollection<Citas>? Citas { get; set; }
    }
}
