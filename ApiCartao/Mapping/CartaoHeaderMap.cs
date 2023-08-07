using BackEndCadastro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace MeuRH.Data.Mapping
{
    public class CartaoHeaderMap: IEntityTypeConfiguration<CartaoHeader>
    {

        public void Configure(EntityTypeBuilder<CartaoHeader> builder)
        {
            builder.HasKey(x => x.CartaoId);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Data);           
            builder.Property(x => x.Lote).IsRequired();           
            builder.Property(x => x.QtdeRegistros).IsRequired();
           
        }
           

    }
}
