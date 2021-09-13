using CurriculoSistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculoSistema.Data.Configuration
{
    public class FormacaoAcademicaConfiguration : IEntityTypeConfiguration<FormacaoAcademica>
    {
        public void Configure(EntityTypeBuilder<FormacaoAcademica> builder)
        {
            builder.HasKey(fa => fa.Id);

            builder.Property(fa => fa.Instituicao).IsRequired().HasMaxLength(50);
            builder.Property(fa => fa.AnoInicio).IsRequired();
            builder.Property(fa => fa.AnoFim).IsRequired();
            builder.Property(fa => fa.NomeCurso).IsRequired().HasMaxLength(50);

            builder.HasOne(fa => fa.TipoCurso).WithMany(fa => fa.FormacoesAcademicas).HasForeignKey(fa => fa.TipoCursoId);
            builder.HasOne(fa => fa.Curriculo).WithMany(fa => fa.FomacoesAcademicas).HasForeignKey(fa => fa.CurriculoId);

            builder.ToTable("FormacaoAcademica");
        }
    }
}
