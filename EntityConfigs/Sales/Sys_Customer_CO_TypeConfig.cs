using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class Sys_Customer_CO_TypeConfig : IEntityTypeConfiguration<SysCustomerCoType>
    {
        public void Configure(EntityTypeBuilder<SysCustomerCoType> entity)
        {

            entity.Property(e => e.Id).ValueGeneratedNever();
        }
    }

}
