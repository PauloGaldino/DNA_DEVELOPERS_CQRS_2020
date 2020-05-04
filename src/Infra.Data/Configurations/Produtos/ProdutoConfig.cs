using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations.Produtos
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        /// <summary>
        /// Classe responsável pela configuração
        /// da Entidade Produto
        /// </summary>
        /// <param name="builder"></param>
       
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Codigo");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(9,2")
                .IsRequired();

            builder.Property(p => p.Lote)
              .HasColumnType("varchar(100)")
              .HasMaxLength(150)
              .IsRequired();

            builder.Property(p => p.DataFabricacao)
                .HasColumnName("Fabricado")
                .HasColumnType("dateTime")
                .IsRequired();

            builder.Property(p => p.DataValidade)
               .HasColumnName("Validade")
               .HasColumnType("dateTime")
               .IsRequired();
        }
    }
}
