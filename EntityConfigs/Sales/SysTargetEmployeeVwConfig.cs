using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SysTargetEmployeeVwConfig : IEntityTypeConfiguration<SysTargetEmployeeVw>
    {
        public void Configure(EntityTypeBuilder<SysTargetEmployeeVw> entity)
        {
            entity.ToView("Sys_Target_Employee_VW");
        }
    }  
}
