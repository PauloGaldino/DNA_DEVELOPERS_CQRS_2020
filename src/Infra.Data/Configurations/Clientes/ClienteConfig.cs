using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations.Clientes
{
    /// <summary>
    /// Classe Responsável pela configuração 
    /// dos atributos da entidade Cliente
    /// </summary>
   
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Id)
                 .HasColumnName("Codigo");

            builder.Property(c => c.Nome)
             .HasColumnType("varchar(100)")
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
