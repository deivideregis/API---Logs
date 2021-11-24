using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class MaquinaMapping : IEntityTypeConfiguration<Maquina>
    {
        public void Configure(EntityTypeBuilder<Maquina> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeMaquina)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.IP)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(p => p.MAC)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(p => p.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            //// 1 : 1 => Maquina : Log
            //builder.HasOne(f => f.Logs)
            //    .WithOne(e => e.Maquina);

            // 1 : N => Maquina(Fornecedor): Log(Produtos)
            builder.HasMany(f => f.Logs)
                .WithOne(p => p.Maquina)
                .HasForeignKey(p => p.MaquinaId);

            builder.ToTable("Maquina");
        }
    }
}
