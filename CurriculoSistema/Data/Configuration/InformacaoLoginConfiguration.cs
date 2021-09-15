using SistemaCurriculos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaCurriculos.Data.Configuration
{
    public class InformacaoLoginConfiguration : IEntityTypeConfiguration<InformacaoLogin>
    {
        public void Configure(EntityTypeBuilder<InformacaoLogin> builder)
        {
            builder.HasKey(il => il.Id);

            builder.Property(il => il.EnderecoIp).IsRequired();
            builder.Property(il => il.Horario).IsRequired();
            builder.Property(il => il.Data).IsRequired();

            builder.HasOne(il => il.Usuario).WithMany(il => il.InformacoesLogin).HasForeignKey(il => il.UsuarioId);

            builder.ToTable("InformacaoLogin");
        }
    }
}
