using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Detalhe)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Acao)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder.ToTable("Log");
        }
    }
}
