using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalPaymentTermConfig : IEntityTypeConfiguration<SalPaymentTerm>
    {
        public void Configure(EntityTypeBuilder<SalPaymentTerm> entity)
        {

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
        }
    }

}
