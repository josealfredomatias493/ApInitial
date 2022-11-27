using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApInitial.Models
{
    public partial class Citas
    {
        [Key]
        public int CtCodigo { get; set; }
        [ForeignKey("Pacientes")]
        public int PacCodigo { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string CtDescripcion { get; set; }
        [ForeignKey("Doctores")]
        public int DocCodigo { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string CtEstatus { get; set; }
       
        public virtual Doctores? Doctores { get; set; }
        public virtual Pacientes? Pacientes { get; set; }
    }
}
