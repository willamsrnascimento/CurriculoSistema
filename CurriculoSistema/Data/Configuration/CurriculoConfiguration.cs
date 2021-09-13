using CurriculoSistema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculoSistema.Data.Configuration
{
    public class CurriculoConfiguration : IEntityTypeConfiguration<Curriculo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Curriculo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.Nome).IsUnique();

            builder.HasOne(c => c.Usuario).WithMany(c => c.Curriculos).HasForeignKey(c => c.UsuarioId);
            builder.HasMany(c => c.Objetivos).WithOne(c => c.Curriculo).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.FomacoesAcademicas).WithOne(c => c.Curriculo).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.ExperienciasProficionais).WithOne(c => c.Curriculo).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Idiomas).WithOne(c => c.Curriculo).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Curriculo");
        }
    }
}
