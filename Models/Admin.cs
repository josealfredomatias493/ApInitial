using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApInitial.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Usuario { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
    }
}
