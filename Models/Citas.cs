using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

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
        [Required]
        public DateTime CtHorarioInicial { get; set; }
        [Required]
        public DateTime CtHorarioFinal { get; set; }
        public virtual Doctores? Doctores { get; set; }=null;
        public virtual Pacientes? Pacientes { get; set; } = null;
        public Citas()
        {
            Optional<Doctores> Doctores= new Doctores();
            Optional<Pacientes> Pacientes = new Pacientes();
        }
    }
}
