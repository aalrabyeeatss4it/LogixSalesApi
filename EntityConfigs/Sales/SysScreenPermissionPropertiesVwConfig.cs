using LogixApi_v02.TestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SysScreenPermissionPropertiesVwConfig : IEntityTypeConfiguration<SysScreenPermissionPropertiesVw>
    {
        public void Configure(EntityTypeBuilder<SysScreenPermissionPropertiesVw> entity)
        {
            entity.ToView("Sys_Screen_Permission_Properties_VW");
        }
    }

}
