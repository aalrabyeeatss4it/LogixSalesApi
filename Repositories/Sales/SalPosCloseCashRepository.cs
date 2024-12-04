
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.TestModels;

namespace LogixApi_v02.Repositories.Sales
{

    public class SalPosCloseCashRepository : GenericRepository<SalPosCloseCash>, ISalPosCloseCashRepository
    {
        public SalPosCloseCashRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task AddISalPosCloseCash(SalPosCloseCash salPosCloseCash)
        {

            var newPosCloseCash = new SalPosCloseCash
            {
                Code = "",
                StarDate = DateTime.Now.ToString("yyyy/MM/dd"),
                EndDate = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd"),
                AmounCash = salPosCloseCash.AmounCash,
                AmountBank = salPosCloseCash.AmountBank,
                BranchId = salPosCloseCash.BranchId,
                FacilityId = salPosCloseCash.FacilityId,
                CreatedBy = salPosCloseCash.CreatedBy,
                CreatedOn = DateTime.Now,
                IsDeleted = false,
                PosId = salPosCloseCash.PosId,
                AccountIdFrom = salPosCloseCash.AccountIdFrom,
                AccountIdTo = salPosCloseCash.AccountIdFrom,
                SalesAmount = salPosCloseCash.SalesAmount,
                ReSalasAmount = salPosCloseCash.ReSalasAmount
            };

            _context.SalPosCloseCash.Add(newPosCloseCash);
            await _context.SaveChangesAsync();

        }


    }
}

