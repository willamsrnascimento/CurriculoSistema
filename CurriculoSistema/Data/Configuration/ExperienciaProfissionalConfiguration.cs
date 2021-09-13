using CurriculoSistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculoSistema.Data.Configuration
{
    public class ExperienciaProfissionalConfiguration : IEntityTypeConfiguration<ExperienciaProfissional>
    {
        public void Configure(EntityTypeBuilder<ExperienciaProfissional> builder)
        {
            builder.HasKey(ep => ep.Id);

            builder.Property(ep => ep.NomeEmpresa).IsRequired().HasMaxLength(50);
            builder.Property(ep => ep.Cargo).IsRequired().HasMaxLength(50);
            builder.Property(ep => ep.AnoInicio).IsRequired();
            builder.Property(ep => ep.AnoFim).IsRequired();
            builder.Property(ep => ep.DescricaoAtividades).IsRequired().HasMaxLength(500);

            builder.HasOne(ep => ep.Curriculo).WithMany(ep => ep.ExperienciasProficionais).HasForeignKey(ep => ep.CurriculoId);

            builder.ToTable("ExperienciaProfissional");
        }
    }
}
