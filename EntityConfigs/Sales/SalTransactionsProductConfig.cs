using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalTransactionsProductConfig : IEntityTypeConfiguration<SalTransactionsProduct>
    {
        public void Configure(EntityTypeBuilder<SalTransactionsProduct> entity)
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.UnitCost).HasDefaultValueSql("((0))");
        }
    }

}
