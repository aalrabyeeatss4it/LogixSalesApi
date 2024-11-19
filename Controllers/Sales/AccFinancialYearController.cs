using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Controllers.Sales
{
    //[Authorize]
    [Route("api/sales/[controller]")]
    [ApiController]
    public class AccFinancialYearController : ControllerBase
    {
        private readonly IAccFinancialYearRepository finYearRepository;
        private readonly ISalTransactionRepository salTransactionRepository;

        public AccFinancialYearController(IAccFinancialYearRepository repository,
            ISalTransactionRepository salTransactionRepository)
        {
            this.finYearRepository = repository;
            this.salTransactionRepository = salTransactionRepository;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<AccFinancialYear>>> GetAll()
        {
            try
            {
                if (finYearRepository.Entities == null)
                {
                    return Result<IEnumerable<AccFinancialYear>>.Fail("There is no Data!!!");
                }
                var list = await finYearRepository.GetAll(f=> f.FlagDelete == false);
                return Result<IEnumerable<AccFinancialYear>>.Sucess(list, "Get Success");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<AccFinancialYear>>.Fail($"Exception: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<Result<AccFinancialYear>> GetById(long id)
        {
            try
            {
                if (finYearRepository.Entities == null)
                {
                    return Result<AccFinancialYear>.Fail("There is no Data!!!");
                }
                var item = await finYearRepository.GetById(id);

                if (item == null)
                {
                    return Result<AccFinancialYear>.Fail($"There is no Data with Id: {id} !!!");
                }

                return Result<AccFinancialYear>.Sucess(item, "");
            }
            catch (Exception ex)
            {
                return Result<AccFinancialYear>.Fail($"Exception: {ex.Message}");
            }
        }


        [HttpGet("GetByTypeId")]
        public async Task<IActionResult> GetByTypeId(int typeId)
        {
            try
            {
                if(typeId == 1)
                {
                    if(salTransactionRepository.Entities == null)
                    {
                        return Ok(Result<IEnumerable<SalTransaction>>.Fail("no data found"));
                    }
                    var trans = await salTransactionRepository.GetAll(t=> t.IsDeleted == false);
                    return Ok(Result<IEnumerable<SalTransaction>>.Sucess(trans ,"transactions"));
                }
                else if (typeId == 2)
                {
                    if (finYearRepository.Entities == null)
                    {
                        return Ok(Result<IEnumerable<AccFinancialYear>>.Fail("no data found"));
                    }
                    var trans = await finYearRepository.GetAll(t => t.FlagDelete == false);
                    return Ok(Result<IEnumerable<AccFinancialYear>>.Sucess(trans, "finYears"));
                }

                 return Ok(Result<string>.Fail("Wrong type id"));
            }
            catch(Exception ex)
            {
                return Ok(Result<string>.Fail($"Exception: {ex.Message}"));
            }
        }

        [HttpPost("Edit/{id}")]
        public async Task<Result<AccFinancialYear>> Edit(int id, AccFinancialYear obj)
        {
            if (id != obj.FinYear)
            {
                return Result<AccFinancialYear>.Fail("There is no Data!!!");
            }

            finYearRepository.Update(obj);

            try
            {
                await finYearRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!IsExists(id))
                {
                    return Result<AccFinancialYear>.Fail("There is no Data!!!");
                }
                else
                {
                    return Result<AccFinancialYear>.Fail($"Exp: {ex.Message}");
                }
            }

            return Result<AccFinancialYear>.Sucess(obj, "Update Done !");
        }

        [HttpPost("Add")]
        public async Task<Result<AccFinancialYear>> Add(AccFinancialYear obj)
        {
            if (obj == null)
            {
                return Result<AccFinancialYear>.Fail("There is no Data!!!");
            }

            var addRes = await finYearRepository.AddAndReturn(obj);

            try
            {
                await finYearRepository.SaveChanges();
                return Result<AccFinancialYear>.Sucess(addRes, "Added Successfylly");
            }
            catch (Exception exp)
            {
                return Result<AccFinancialYear>.Fail($"Exp in add of: {GetType().Name}, Message: {exp.Message} --- {(exp.InnerException != null ? "InnerExp: " + exp.InnerException.Message : "no inner")} .");
            }
        }


        [HttpDelete("Delete/{id}")]
        public async Task<Result<AccFinancialYear>> Delete(int id)
        {
            if (await finYearRepository.GetAll() == null)
            {
                return Result<AccFinancialYear>.Fail("There is no Data!!!");
            }
            var item = await finYearRepository.GetById(id);
            if (item == null)
            {
                return Result<AccFinancialYear>.Fail("There is no Data!!!");
            }

            var deleteRes = finYearRepository.RemoveAndReturn(item);
            try
            {
                await finYearRepository.SaveChanges();
                return Result<AccFinancialYear>.Sucess(deleteRes, "Deleted Successfylly");
            }
            catch (Exception ex)
            {
                return Result<AccFinancialYear>.Fail($"Exp: {ex.Message}");
            }

        }

        private bool IsExists(int id)
        {
            return (finYearRepository.Entities?.Any(e => e.FinYear == id)).GetValueOrDefault();
        }
    }

    
}
