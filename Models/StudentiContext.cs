using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Skola.Models
{
    public class StudentiContext : DbContext
    {
        public StudentiContext (DbContextOptions<StudentiContext> options)
            : base(options)
        {
        }
        
        public DbSet<Skola.Models.Studenti> Studenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-013A96I\\SQLEXPRESS;Database=Skola;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Studenti>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.JMBG).HasColumnName("JMBG");

                entity.Property(e => e.Ime).HasColumnName("Ime").HasMaxLength(15);

                entity.Property(e => e.MestoRođenja).HasColumnName("MestoRođenja").HasMaxLength(30);

                entity.Property(e => e.Prezime).HasColumnName("Prezime").HasMaxLength(25);
            });
        }
    }
}
