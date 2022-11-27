using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApInitial.Models
{
    public partial class CITASMEDICASContext : DbContext
    {
        public CITASMEDICASContext()
        {
        }

        public CITASMEDICASContext(DbContextOptions<CITASMEDICASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Doctores> Doctores { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

    }
}