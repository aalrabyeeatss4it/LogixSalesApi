using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class WhInventoryConfig : IEntityTypeConfiguration<WhInventory>
    {
        public void Configure(EntityTypeBuilder<WhInventory> entity)
        {
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");
        }
    }

}
