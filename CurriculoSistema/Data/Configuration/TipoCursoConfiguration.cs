using SistemaCurriculos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaCurriculos.Data.Configuration
{
    public class TipoCursoConfiguration : IEntityTypeConfiguration<TipoCurso>
    {
        public void Configure(EntityTypeBuilder<TipoCurso> builder)
        {
            builder.HasKey(tc => tc.Id);
            
            builder.Property(tc => tc.Tipo).IsRequired();
            
            builder.HasIndex(tc => tc.Tipo).IsUnique();

            builder.HasMany(tc => tc.FormacoesAcademicas).WithOne(tc => tc.TipoCurso).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
