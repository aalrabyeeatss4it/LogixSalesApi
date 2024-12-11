using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class AccFinancialYearConfig : IEntityTypeConfiguration<AccFinancialYear>
    {
        public void Configure(EntityTypeBuilder<AccFinancialYear> entity)
        {
            entity.Property(e => e.FlagDelete).HasDefaultValueSql("((0))");
        }
    }

}
