using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class WhInventoriesVwConfig : IEntityTypeConfiguration<WhInventoriesVw>
    {
        public void Configure(EntityTypeBuilder<WhInventoriesVw> entity)
        {

            entity.ToView("WH_Inventories_VW");
        }
    }
}
