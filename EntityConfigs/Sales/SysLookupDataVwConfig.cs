using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SysLookupDataVwConfig : IEntityTypeConfiguration<SysLookupDataVw>
    {
        public void Configure(EntityTypeBuilder<SysLookupDataVw> entity)
        {
            entity.ToView("Sys_lookup_Data_VW");
        }
    }

}
