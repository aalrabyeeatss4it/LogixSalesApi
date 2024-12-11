using LogixApi_v02.Models;
using LogixApi_v02.TestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class WhItemsInventoryVwConfig : IEntityTypeConfiguration<WhItemsInventoryVw>
    {
        public void Configure(EntityTypeBuilder<WhItemsInventoryVw> entity)
        {

            entity.ToView("WH_Items_Inventory_VW");
        }
    }
}
