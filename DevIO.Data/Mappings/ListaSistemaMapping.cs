using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ListaSistemaMapping : IEntityTypeConfiguration<ListaSistema>
    {
        public void Configure(EntityTypeBuilder<ListaSistema> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NumeroSistema)
                .IsRequired()
                .HasColumnType("varchar(3)");

            builder.Property(p => p.NomeSistema)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("ListaSistema");
        }
    }
}
