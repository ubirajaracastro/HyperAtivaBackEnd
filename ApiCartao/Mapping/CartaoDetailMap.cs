using BackEndCadastro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuRH.Data.Mapping
{
    public class CartaoDetailMap : IEntityTypeConfiguration<CartaoDetail>
    {
        public void Configure(EntityTypeBuilder<CartaoDetail> builder)
        {
           
            builder.HasKey(x => x.CartaoDetalId);

            builder.Property(x => x.NumeroCartao).IsRequired();
            builder.Property(x => x.Identificador).IsRequired();
            builder.Property(x => x.NumeroLote).IsRequired();
            builder.Property(x => x.NumeroCartaoCompleto).IsRequired();
           
        }
    }

}
