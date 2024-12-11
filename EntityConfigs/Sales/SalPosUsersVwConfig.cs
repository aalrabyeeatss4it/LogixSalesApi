using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalPosUsersVwConfig : IEntityTypeConfiguration<SalPosUsersVw>
    {
        public void Configure(EntityTypeBuilder<SalPosUsersVw> entity)
        {
            entity.ToView("SAL_POS_Users_VW");
        }
    }

}
