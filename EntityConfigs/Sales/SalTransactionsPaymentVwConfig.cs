using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalTransactionsPaymentVwConfig : IEntityTypeConfiguration<SalTransactionsPaymentVw>
    {
        public void Configure(EntityTypeBuilder<SalTransactionsPaymentVw> entity)
        {
            entity.ToView("SAL_Transactions_Payment_VW");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.PaymentDate).IsFixedLength();

            entity.Property(e => e.PaymentDate2).IsFixedLength();
        }
    }

}
