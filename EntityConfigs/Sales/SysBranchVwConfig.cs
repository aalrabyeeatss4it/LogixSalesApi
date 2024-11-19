using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SysBranchVwConfig : IEntityTypeConfiguration<SysBranchVw>
    {
        public void Configure(EntityTypeBuilder<SysBranchVw> entity)
        {
            entity.ToView("SYS_BRANCH_VW");
        }
    }

}
