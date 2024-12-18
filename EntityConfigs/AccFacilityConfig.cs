﻿
using LogixApi_v02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs
{
    public class AccFacilityConfig : IEntityTypeConfiguration<AccFacility>
    {
        public void Configure(EntityTypeBuilder<AccFacility> entity)
        {
            entity.HasKey(e => e.FacilityId)
                    .HasName("PK_Facilities");

            entity.Property(e => e.AccountBranches).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountCash).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountCashSales).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountChequ).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountChequUnderCollection).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountContractors).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountCostGoodsSold).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountCostSales).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountCustomer).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountFeeManage).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountInstallmentsUnderCollection).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountInventoryTransit).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountInvestor).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountInvestorProfits).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountMerchandiseInventory).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountProfitInstallment).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountProfitInstallmentDeferred).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountReceivablesSales).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountSales).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountSalesProfits).HasDefaultValueSql("((0))");

            entity.Property(e => e.AccountSupplier).HasDefaultValueSql("((0))");

            entity.Property(e => e.CcIdItems).HasDefaultValueSql("((0))");

            entity.Property(e => e.CcIdProjects).HasDefaultValueSql("((0))");

            entity.Property(e => e.DiscountAccountId).HasDefaultValueSql("((0))");

            entity.Property(e => e.DiscountCreditAccountId).HasDefaultValueSql("((0))");

            entity.Property(e => e.FlagDelete).HasDefaultValueSql("((0))");

            entity.Property(e => e.GroupAssets).HasDefaultValueSql("((0))");

            entity.Property(e => e.GroupCopyrights).HasDefaultValueSql("((0))");

            entity.Property(e => e.GroupExpenses).HasDefaultValueSql("((0))");

            entity.Property(e => e.GroupIncame).HasDefaultValueSql("((0))");

            entity.Property(e => e.GroupLiabilities).HasDefaultValueSql("((0))");

            entity.Property(e => e.InsertDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Posting).HasDefaultValueSql("((1))");

            entity.Property(e => e.SalesAccountType).HasDefaultValueSql("((1))");

            entity.Property(e => e.SeparateAccountCustomer).HasDefaultValueSql("((2))");

            entity.Property(e => e.SeparateAccountSupplier).HasDefaultValueSql("((2))");

            entity.Property(e => e.UsingPurchaseAccount).HasDefaultValueSql("((0))");
        }
    }

}
