using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SysCustomerVwConfig : IEntityTypeConfiguration<SysCustomerVw>
    {
        public void Configure(EntityTypeBuilder<SysCustomerVw> entity)
        {

            entity.ToView("Sys_Customer_VW");
        }
    }
}
