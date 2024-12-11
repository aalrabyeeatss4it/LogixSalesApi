using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SysCustomerConfig : IEntityTypeConfiguration<SysCustomer>
    {
        public void Configure(EntityTypeBuilder<SysCustomer> entity)
        {
            entity.Property(e => e.CurrencyId).HasDefaultValueSql("((1))");

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.Iscompleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.OwnerProperty).HasDefaultValueSql("((0))");

            entity.Property(e => e.RateFileCompletion).HasDefaultValueSql("((0))");

            entity.Property(e => e.TitleId).HasComment("اللقب");

            entity.Property(e => e.Veneration).HasComment("التبجيل");
        }
    }

}
