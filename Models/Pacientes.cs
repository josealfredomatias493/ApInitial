using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApInitial.Models
{
    public partial class Pacientes
    {
      
        [Key]
        public int PacCodigo { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string PacNombre { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string PacApellido { get; set; } 
        public DateTime PacFechaNacimiento { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string? PacTelefono { get; set; }
        [EmailAddress, Column(TypeName = "varchar(200)")]
        public string? PacEmail { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string PacDireccion { get; set; }
        [ForeignKey("Usuario")]
        public int UserCodigo { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string PacEstatus { get; set; }

        [NotMapped]
        public virtual Usuarios? usuarios { get; set; }
        public virtual ICollection<Citas>? citas { get; set; }
    }
}
