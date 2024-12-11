using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalPosSettingVwConfig : IEntityTypeConfiguration<SalPosSettingVw>
    {
        public void Configure(EntityTypeBuilder<SalPosSettingVw> entity)
        {
            entity.ToView("SAL_POS_Setting_VW");
        }
    }

}
