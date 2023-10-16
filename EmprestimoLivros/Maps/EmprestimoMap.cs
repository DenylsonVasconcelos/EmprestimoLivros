using EmprestimoLivros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprestimoLivros.Maps
{
    public class EmprestimoMap : IEntityTypeConfiguration<EmprestimoModel>
    {
        public void Configure(EntityTypeBuilder<EmprestimoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Recebedor).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Fornecedor).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.LivroEmprestado).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.DataEmpretimo).IsRequired();
        }
    }
}
