using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using LogixApi_v02.Models;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.EntityConfigs;
using LogixApi_v02.EntityConfigs.Sales;
using LogixApi_v02.ViewModels.Sales;
using LogixApi_v02.Models.Wh;
using LogixApi_v02.ViewModels;
using LogixApi_v02.TestModels;

namespace LogixApi_v02.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        internal object WhItemsVw;
        internal object InvestBranch;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /*   Each region is for one system entities   */
        //===================== Sales ==========================


        public DbSet<SysMobileMember> SysMobileMembers { get; private set; }
        public DbSet<SysPropertyValuesVw> SysPropertyValuesVw { get; private set; }
        public DbSet<SalTransaction> SalTransactions { get; private set; }
        public DbSet<SalTransactionsProduct> SalTransactionsProducts { get; private set; }
        public DbSet<SalTransactionsProductsVw> SalTransactionsProductsVws{ get; private set; }
        public DbSet<SalTransactionsVw> SalTransactionsVws { get; private set; }
        public DbSet<SalPaymentTerm> SalPaymentTerms { get; private set; }
        public DbSet<AccFinancialYear> AccFinancialYears { get; private set; }
        public DbSet<SysCustomer> SysCustomers { get; private set; }
     
        public DbSet<SysCustomerVw> SysCustomerVws { get; private set; }

        public DbSet<WhItem> WhItems { get; private set; }
        public DbSet<WhItemsVw> WhItemsVws { get; private set; }
        public DbSet<SysCustomerType> SysCustomerTypes { get; private set; }
        public DbSet<InvestBranch> InvestBranchs { get; private set; }
        public DbSet<SysBranch> SysBranches { get; private set; }
        public DbSet<SysBranchVw> SysBranchVws { get; private set; }
        public DbSet<SysCustomerCoType> SysCustomerCoTypes { get; private set; }
        public DbSet<SysCustomerGroup> SysCustomerGroups { get; private set; }
        public DbSet<WhInventory> WhInventories { get; private set; }
        public DbSet<SalTransactionsPayment> SalTransactionsPayments { get; private set; }
        public DbSet<SalTransactionsPaymentVw> SalTransactionsPaymentVws { get; private set; }
        public DbSet<WhInventoriesVw> WhInventoriesVws { get; private set; }
        public DbSet<SalPosSetting> SalPosSettings { get; private set; }
        public DbSet<SalPosSettingVw> SalPosSettingVws { get; private set; }
        public DbSet<SalPosUser> SalPosUsers { get; private set; }
        public DbSet<SalPosUsersVw> SalPosUsersVws { get; private set; }
        public DbSet<SysLookupData> SysLookupDatas { get; private set; }
        public DbSet<SysLookupDataVw> SysLookupDataVws { get; private set; }
        public DbSet<SysTargetEmployeeVw> SysTargetEmployeeVws { get; private set; }
        public DbSet<SalTransactionsDiscountVw> SalTransactionsDiscountVw { get; private set; }

        //----------------------logix pos--------------------------------------------
        public DbSet<WhItemsInventoryVw> WhItemsInventoryVw { get; private set; }
        public DbSet<SalPosCloseCash> SalPosCloseCash { get; private set; }


        //=============== All ====================
        public DbSet<SysUser> SysUsers { get; private set; }
        public DbSet<AccFacilitiesVw> AccFacilitiesVw { get; private set; }
        public DbSet<SysUserVw> SysUserVws { get; private set; }
        public DbSet<SysSystem> sysSystems { get; private set; }
        public DbSet<MainListDto> MainListDtos { get; private set; }
        public DbSet<SubListDto> SubListDtos { get; private set; }
        public DbSet<SysScreenPermission> SysScreenPermissions { get; private set; }
        public DbSet<SysScreenPermissionPropertiesVw> SysScreenPermissionPropertiesVw { get; private set; }

        //====================WH===================
        public DbSet<WhItemsUnitVw> WhItemsUnitVws { get; private set; }
        public DbSet<WhItemsGetBalance> WhItemsGetBalance { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             modelBuilder.ApplyConfiguration(new SysUserConfig());

            //======================= AccFacilityConfig ==========================================

            modelBuilder.ApplyConfiguration(new AccFacilityConfig());
            modelBuilder.ApplyConfiguration(new AccFacilitiesVwConfig());
            modelBuilder.ApplyConfiguration(new SysPropertyValuesVwConfig());

            //=========================== Sales==================================================
             modelBuilder.ApplyConfiguration(new SalPosCloseCashConfig());
             modelBuilder.ApplyConfiguration(new SalTransactionsVwConfig());
             modelBuilder.ApplyConfiguration(new AccFinancialYearConfig());
             modelBuilder.ApplyConfiguration(new SalTransactionsProductsVwConfig());
             modelBuilder.ApplyConfiguration(new SalTransactionsProductConfig());
             modelBuilder.ApplyConfiguration(new SalPaymentTermConfig());    
             modelBuilder.ApplyConfiguration(new SysCustomerConfig());
             modelBuilder.ApplyConfiguration(new SysCustomerVwConfig());
             modelBuilder.ApplyConfiguration(new WhItemConfig());
             modelBuilder.ApplyConfiguration(new WhItemsVwConfig());
             modelBuilder.ApplyConfiguration(new SysCustomerTypeConfig());
             modelBuilder.ApplyConfiguration(new InvestBranchConfig());
             modelBuilder.ApplyConfiguration(new SysBranchConfig());
             modelBuilder.ApplyConfiguration(new SysBranchVwConfig());
             modelBuilder.ApplyConfiguration(new Sys_Customer_CO_TypeConfig());
             modelBuilder.ApplyConfiguration(new SysCustomerGroupConfig());
             modelBuilder.ApplyConfiguration(new WhInventoryConfig());
             modelBuilder.ApplyConfiguration(new WhInventoriesVwConfig());
             modelBuilder.ApplyConfiguration(new WhInventoriesVwConfig());
             modelBuilder.ApplyConfiguration(new SalTransactionsPaymentConfig());
             modelBuilder.ApplyConfiguration(new SalPosSettingConfig());
             modelBuilder.ApplyConfiguration(new SalPosSettingVwConfig());
             modelBuilder.ApplyConfiguration(new SalPosUserConfig   ());
             modelBuilder.ApplyConfiguration(new SalPosUsersVwConfig());
             modelBuilder.ApplyConfiguration(new SysLookupDataConfig());
             modelBuilder.ApplyConfiguration(new SysLookupDataVwConfig());
             modelBuilder.ApplyConfiguration(new SysTargetEmployeeVwConfig());
             modelBuilder.ApplyConfiguration(new SalTransactionsDiscountVwConfig());
             modelBuilder.ApplyConfiguration(new SysScreenPermissionPropertiesVwConfig());
            //--------------------------sale pos-------------------
            modelBuilder.ApplyConfiguration(new WhItemsInventoryVwConfig());

        }
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }*/
        //   partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
