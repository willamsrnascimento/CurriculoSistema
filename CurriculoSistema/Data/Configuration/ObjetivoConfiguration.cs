using CurriculoSistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculoSistema.Data.Configuration
{
    public class ObjetivoConfiguration : IEntityTypeConfiguration<Objetivo>
    {
        public void Configure(EntityTypeBuilder<Objetivo> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Descricao).IsRequired().HasMaxLength(1000);

            builder.HasOne(o => o.Curriculo).WithMany(o => o.Objetivos).HasForeignKey(o => o.CurriculoId);

            builder.ToTable("Objetivo");
        }
    }
}
