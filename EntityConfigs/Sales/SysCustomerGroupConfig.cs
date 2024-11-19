using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SysCustomerGroupConfig : IEntityTypeConfiguration<SysCustomerGroup>
    {
        public void Configure(EntityTypeBuilder<SysCustomerGroup> entity)
        {
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        }
    }

}
