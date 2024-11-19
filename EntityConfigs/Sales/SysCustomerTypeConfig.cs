using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SysCustomerTypeConfig : IEntityTypeConfiguration<SysCustomerType>
    {
        public void Configure(EntityTypeBuilder<SysCustomerType> entity)
        {
            entity.Property(e => e.TypeId).ValueGeneratedNever();
        }
    }

}
