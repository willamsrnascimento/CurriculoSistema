using Microsoft.EntityFrameworkCore;
using SistemaCurriculos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaCurriculos.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(50);

            builder.HasMany(u => u.Curriculos).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.InformacoesLogin).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Usuario");
        }
    }
}
