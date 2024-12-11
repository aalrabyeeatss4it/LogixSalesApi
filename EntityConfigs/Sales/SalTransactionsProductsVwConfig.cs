using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalTransactionsProductsVwConfig : IEntityTypeConfiguration<SalTransactionsProductsVw>
    {
        public void Configure(EntityTypeBuilder<SalTransactionsProductsVw> entity)
        {
            entity.ToView("SAL_Transactions_Products_VW");
        }
    }

}
