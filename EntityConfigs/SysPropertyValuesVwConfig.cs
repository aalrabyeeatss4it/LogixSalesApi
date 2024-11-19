using LogixApi_v02.TestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs
{
    public class SysPropertyValuesVwConfig : IEntityTypeConfiguration<SysPropertyValuesVw>
    {
        public void Configure(EntityTypeBuilder<SysPropertyValuesVw> entity)
        {
            entity.ToView("Sys_Property_Values_VW");
        }
    }

}
