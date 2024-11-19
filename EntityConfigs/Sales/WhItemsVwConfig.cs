using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class WhItemsVwConfig : IEntityTypeConfiguration<WhItemsVw>
    {
        public void Configure(EntityTypeBuilder<WhItemsVw> entity)
        {
            entity.ToView("Wh_Items_VW");
        }
    }

}
