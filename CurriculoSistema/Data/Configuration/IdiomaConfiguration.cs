using SistemaCurriculos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaCurriculos.Data.Configuration
{
    public class IdiomaConfiguration : IEntityTypeConfiguration<Idioma>
    {
        public void Configure(EntityTypeBuilder<Idioma> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome).IsRequired().HasMaxLength(50);
            builder.HasIndex(i => i.Nome).IsUnique();
            builder.Property(i => i.Nivel).IsRequired().HasMaxLength(50);

            builder.HasOne(i => i.Curriculo).WithMany(i => i.Idiomas).HasForeignKey(i => i.CurriculoId);

            builder.ToTable("Idioma");
        }
    }
}
