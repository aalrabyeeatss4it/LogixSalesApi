using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SysLookupDataConfig : IEntityTypeConfiguration<SysLookupData>
    {
        public void Configure(EntityTypeBuilder<SysLookupData> entity)
        {
            entity.Property(e => e.Isdel).HasDefaultValueSql("((0))");
        }
    }

}
