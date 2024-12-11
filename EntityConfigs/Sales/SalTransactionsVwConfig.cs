using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs.Sales
{
    public class SalTransactionsVwConfig : IEntityTypeConfiguration<SalTransactionsVw>
    {
        public void Configure(EntityTypeBuilder<SalTransactionsVw> entity)
        {
            entity.ToView("SAL_Transactions_VW");
        }
    }

}
