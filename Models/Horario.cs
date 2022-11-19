﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApInitial.Models
{
    public partial class Horario
    {
        [Key]
        public int HrCodigo { get; set; }
        public DateTime HrIncio { get; set; }
        public DateTime HrFinal { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string HrEstatus { get; set; }
        public virtual ICollection<Doctores>? Doctores { get; set; }
    }
}
