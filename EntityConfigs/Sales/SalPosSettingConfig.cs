using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalPosSettingConfig : IEntityTypeConfiguration<SalPosSetting>
    {
        public void Configure(EntityTypeBuilder<SalPosSetting> entity)
        {

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.Online).HasDefaultValueSql("((1))");
        }

    }
}
