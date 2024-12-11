using LogixApi_v02.TestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalTransactionsDiscountVwConfig : IEntityTypeConfiguration<SalTransactionsDiscountVw>
    {
        public void Configure(EntityTypeBuilder<SalTransactionsDiscountVw> entity)
        {
            entity.ToView("SAL_Transactions_Discount_VW");

            entity.Property(e => e.DiscountDate).IsFixedLength();

            entity.Property(e => e.DiscountDate2).IsFixedLength();
        }
    }

}
