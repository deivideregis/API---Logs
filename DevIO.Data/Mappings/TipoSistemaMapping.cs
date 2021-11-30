using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class TipoSistemaMapping : IEntityTypeConfiguration<TipoSistema>
    {
        public void Configure(EntityTypeBuilder<TipoSistema> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NumeroSistema)
                .IsRequired()
                .HasColumnType("varchar(3)");

            builder.Property(p => p.NomeSistema)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("TipoSistema");
        }
    }
}
