using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalTransactionsPaymentConfig : IEntityTypeConfiguration<SalTransactionsPayment>
    {
        public void Configure(EntityTypeBuilder<SalTransactionsPayment> entity)
        {

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.PaymentDate).IsFixedLength();

            entity.Property(e => e.PaymentDate2).IsFixedLength();
        }
    }

}
