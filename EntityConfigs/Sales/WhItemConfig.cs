using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class WhItemConfig : IEntityTypeConfiguration<WhItem>
    {
        public void Configure(EntityTypeBuilder<WhItem> entity)
        {
            entity.Property(e => e.AccountId).HasDefaultValueSql("((0))");

            entity.Property(e => e.CcId).HasDefaultValueSql("((0))");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.FacilityId).HasDefaultValueSql("((1))");

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.ItemType).HasComment("1 products 2 services");

            entity.Property(e => e.ItemType2).HasComment("1 products 2 services");

            entity.Property(e => e.PriceIncludeVat).HasDefaultValueSql("((0))");
        }
    }

}
