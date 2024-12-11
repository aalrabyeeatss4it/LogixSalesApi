using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class InvestBranchConfig : IEntityTypeConfiguration<InvestBranch>
    {
        public void Configure(EntityTypeBuilder<InvestBranch> entity)
        {

            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

            entity.Property(e => e.Isdel).HasDefaultValueSql("((0))");
        }
    }
}
