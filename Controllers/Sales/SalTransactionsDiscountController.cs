using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.TestModels;
using LogixApi_v02.ViewModels;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixApi_v02.Controllers.Sales
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalTransactionsDiscountController : ControllerBase
    {
        private readonly ISalTransactionsDiscountVwRepository salTransactionsDiscountVw;

        public SalTransactionsDiscountController(ISalTransactionsDiscountVwRepository salTransactionsDiscountVw)
        {
            this.salTransactionsDiscountVw = salTransactionsDiscountVw;
        }

        [HttpGet("transactionsDiscount")]

        public async Task<ResultPagination<IEnumerable<SalTransactionsDiscountVw>>> GetTransactionsDiscount(int? page, int? size, string? Customer_NAME,
         string? Code,
         string? invoiceCode,
         string? Branch_ID,
       
         string? Payment_Terms_ID,
         string? start_date,
         string? end_date)
        {


            long Facility_ID = long.Parse(User.FindFirst("Facility_ID").Value);
            long Emp_ID = long.Parse(User.FindFirst("Emp_ID")?.Value);
            string SalesType = long.Parse(User.FindFirst("Sales_Type")?.Value).ToString();


            try
            {



                if (salTransactionsDiscountVw.Entities == null)
                {
                    return ResultPagination<IEnumerable<SalTransactionsDiscountVw>>.Fail("There is no Data!!!");
                }

                //DateTime currentDate = DateTime.Now;
                //int currentYear = currentDate.Year;
                //int month = currentDate.Month;
                //int lastDay = DateTime.DaysInMonth(currentYear, month);
                //string currentMonth = month.ToString("D2");  // Ensures a leading zero if needed

                //start_date ??= $"{currentYear}/{currentMonth}/01";
                //end_date ??= $"{currentYear}/{currentMonth}/{lastDay}";


                var list = await salTransactionsDiscountVw.GetAll(d => d.FacilityId == Facility_ID );
                Pagination pagination = new Pagination(page ?? 1, list.Count(), size ?? 25);
                var res = new List<SalTransactionsDiscountVw>();
                if (SalesType != "0")
                {
                    res = list.Where(d => d.EmpId == Emp_ID).ToList();
                }
                else
                {
                    res = list.ToList();
                }

                var vmList = new List<SalTransactionsDiscountVw>();

                if (!string.IsNullOrEmpty(Customer_NAME))
                {
                    try
                    {
                        res = res.Where(t => t.CustomerName != null && t.CustomerName.Contains(Customer_NAME)).ToList();

                    }
                    catch (Exception exc)
                    {

                    }
                }
                if (!string.IsNullOrEmpty(Code))
                {
                    try
                    {
                        res = res.Where(t => t.Code != null && t.Code.Contains(Code)).ToList();
                    }
                    catch (Exception exc)
                    {

                    }

                }
                if (!string.IsNullOrEmpty(invoiceCode))
                {
                    try
                    {
                        res = res.Where(t => t.InvoiceCode != null && t.Total.ToString().Contains(invoiceCode)).ToList();

                    }
                    catch (Exception exc)
                    {

                    }
                }

                if (!string.IsNullOrEmpty(Branch_ID))
                {
                    try
                    {
                        res = res.Where(t => t.BranchId != null && t.BranchId == int.Parse(Branch_ID)).ToList();

                    }
                    catch (Exception exc)
                    {

                    }
                }

         

                if (!string.IsNullOrEmpty(Payment_Terms_ID))
                {
                    try
                    {
                        res = res.Where(t => t.PaymentTermsId != null && t.PaymentTermsId == int.Parse(Payment_Terms_ID)).ToList();
                    }
                    catch (Exception exc)
                    {

                    }
                }

                if (!string.IsNullOrEmpty(start_date) && !string.IsNullOrEmpty(end_date))
                {
                    List<SalTransactionsDiscountVw> templist = new List<SalTransactionsDiscountVw>();
                    foreach (var item in res)
                    {

                        var dateTemp = DateHelper.FixConvertDateFormate(item.Date1);
                        if (dateTemp != null)
                        {
                            if (DateHelper.StringToDate1(item.Date1) >= DateHelper.StringToDate1(start_date) &&
                                 DateHelper.StringToDate1(item.Date1) <= DateHelper.StringToDate1(end_date))
                            {
                                templist.Add(item);
                            }
                        }
                    }
                    res = templist;
                }
                var data = res.OrderByDescending(a => a.Id)
              .Skip(pagination.Size * (pagination.CurrentPage - 1))
             .Take(pagination.Size)
           .ToList();

                return ResultPagination<IEnumerable<SalTransactionsDiscountVw>>.Sucess(pagination, data, "");
            }
            catch (Exception ex)
            {
                return ResultPagination<IEnumerable<SalTransactionsDiscountVw>>.Fail($"Exception: {ex.Message}");
            }



        }
    
    
    }
}
