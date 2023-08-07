using BackEndCadastro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndCadastro.Mapping
{
    public class UsuarioMap: IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.UsuarioId).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.Login).IsRequired();
        }
    }
}
