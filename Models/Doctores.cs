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
        [Column(TypeName = "varchar(200)")]
        public string DocEspecialidades { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string DocEstatus { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string DocUsuario { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string DocPassword { get; set; }

        [NotMapped]
        public virtual ICollection<Citas>? Citas { get; set; }
        public virtual ICollection<Horario>? Horarios { get; set; }


    }
}
