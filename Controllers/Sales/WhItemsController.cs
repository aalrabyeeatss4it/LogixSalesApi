using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.Repositories.Sales;
using LogixApi_v02.TestModels;
using LogixApi_v02.ViewModels;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LogixApi_v02.Controllers.Sales
{
    [Route("api/[controller]")]

    [ApiController]
    public class WhItemsController : ControllerBase
    {   

         private readonly IWhItemRepository repository;
        private readonly ISysScreenPermissionPropertiesVwRepository sysScreenPermissionPropertiesVw;
        private readonly IWhItemsInventoryVwRepository whItemsInventoryVw;

        public WhItemsController(IWhItemRepository repository, ISysScreenPermissionPropertiesVwRepository sysScreenPermissionPropertiesVw, IWhItemsInventoryVwRepository whItemsInventoryVw)
        {
            this.repository = repository;
            this.sysScreenPermissionPropertiesVw = sysScreenPermissionPropertiesVw;
            this.whItemsInventoryVw = whItemsInventoryVw;
        }

        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<WhItem>>> GetAll()
        {
            try
            {
                if (repository.Entities == null)
                {
                    return Result<IEnumerable<WhItem>>.Fail("There is no Data!!!");
                }
                var list = await repository.GetAll(d => d.IsDeleted == false);
                return Result<IEnumerable<WhItem>>.Sucess(list, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<WhItem>>.Fail($"Exception: {ex.Message}");
            }

        }        [HttpGet("getAllItembyInventory")]
        public async Task<Result<IEnumerable<WhItemsInventoryVw>>> GetAllItembyInventory(int inverntory)
        {
            try
            {
                if (repository.Entities == null)
                {
                    return Result<IEnumerable<WhItemsInventoryVw>>.Fail("There is no Data!!!");
                }
                var list = await whItemsInventoryVw.GetAll(d => d.IsDeleted == false&&d.InventoryId==inverntory);
                return Result<IEnumerable<WhItemsInventoryVw>>.Sucess(list, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<WhItemsInventoryVw>>.Fail($"Exception: {ex.Message}");
            }

        }


        [HttpGet("getItemById")]
        public async Task<Result<WhItem>> GetById(long id)
        {
            try
            {
                if (repository.Entities == null)
                {
                    return Result<WhItem>.Fail("There is no Data!!!");
                }
                var item = await repository.GetById(id);
                if(item == null)
                {
                    return Result<WhItem>.Fail($"There is no data with id {id}");
                }
                return Result<WhItem>.Sucess(item, "");
            }
            catch (Exception ex)
            {
                return Result<WhItem>.Fail($"Exception: {ex.Message}");
            }

        }


        [HttpGet("GetAllItem")]
        public async Task<Result<IEnumerable<WhItemsVM>>> GetAllItem()
        {
            try
            {
                //var test = User.FindFirst("Emp_Code")?.Value;

                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var EmpId = User.FindFirst("Emp_ID")?.Value;
                var EmpIdLong = long.Parse(EmpId ?? "0");
                var res = await repository.GetAllOther<WhItemsVw>();
                if (res == null)
                {
                    return Result<IEnumerable<WhItemsVM>>.Fail("There is no Data!!!");
                }
                var vmList = new List<WhItemsVM>();
                vmList = res.Where(d => d.IsDeleted == false && d.FacilityId == faId ).Select(d => new WhItemsVM
                {
                    Id = d.Id,
                    ItemCode = d.ItemCode,
                    ItemName = d.ItemName,
                    PriceSale = d.PriceSale,
                    PurchasePrice = d.PurchasePrice,
                    UnitName = d.UnitName,
                    VatRate = d.VatRate,
                    CatName = d.CatName,
                    UnitItemId = d.UnitItemId,
                    VatEnable = d.VatEnable,
                    PriceIncludeVat = d.PriceIncludeVat,
                    CreatedOn = d.CreatedOn
                   
                }).OrderByDescending(s => s.Id).ToList();
                return Result<IEnumerable<WhItemsVM>>.Sucess(vmList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<WhItemsVM>>.Fail($"Exception: {ex.Message}");
            }

        }
        [HttpGet("GetAllItemPagination")]
        public async Task<ResultPagination<IEnumerable<WhItemsVM>>> GetAllItemPagination(int? page, int? size, string ?Item_code)
        {
            try
            {
                //var test = User.FindFirst("Emp_Code")?.Value;

                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var EmpId = User.FindFirst("Emp_ID")?.Value;
                var EmpIdLong = long.Parse(EmpId ?? "0");
                var res = await repository.GetAllOther<WhItemsVw>();
                if (res == null)
                {
                    return ResultPagination<IEnumerable<WhItemsVM>>.Fail("There is no Data!!!");
                }

                if (!string.IsNullOrEmpty(Item_code))
                {
                    res = res.Where(t =>  t.ItemName.IndexOf(Item_code, StringComparison.OrdinalIgnoreCase) >= 0 || t.ItemCode.IndexOf(Item_code, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                var vmList = new List<WhItemsVM>();

                Pagination pagination = new Pagination(page ?? 1, res.Count(), size ?? 25);



                vmList = res.Where(d => d.IsDeleted == false &&d.StatusId ==1 && d.FacilityId == faId).Select(d => new WhItemsVM
                {
                    Id = d.Id,
                    ItemCode = d.ItemCode,
                    ItemName = d.ItemName,
                    PriceSale = d.PriceSale,
                    PurchasePrice = d.PurchasePrice,
                    UnitName = d.UnitName,
                    VatRate = d.VatRate,
                    CatName = d.CatName,
                    UnitItemId = d.UnitItemId,
                    VatEnable = d.VatEnable,
                    PriceIncludeVat = d.PriceIncludeVat,
                    CreatedOn = d.CreatedOn

                }).OrderByDescending(a => a.Id)
              .Skip(pagination.Size * (pagination.CurrentPage - 1))
             .Take(pagination.Size)
           .ToList();
                return ResultPagination<IEnumerable<WhItemsVM>>.Sucess(pagination,vmList, "");
            }
            catch (Exception ex)
            {
                return ResultPagination<IEnumerable<WhItemsVM>>.Fail($"Exception: {ex.Message}");
            }

        }





        [HttpGet("GetBalanceItem")]

        public async Task<Result<decimal>> GetBalanceItem(long ItemID,
    int UnitItemId, int inventoryID)
        {
            try
            {
          
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);


                var list = await repository.GetQuantityItem(ItemID, UnitItemId, inventoryID
                    );
                return Result<decimal>.Sucess(list, "");
            }
            catch (Exception ex)
            {
                return Result<decimal>.Fail($"Exception: {ex.Message}");
            }

        }

        [HttpGet("GetCheck_Price_Last_Items")]

        public async Task<Result<decimal>> GetBalGetCheck_Price_Last_ItemsanceItem(string ItemCode,
    string custmer_code )
        {
            try
            {
          
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);


                var list = await repository.GetCheck_Price_Last_Items(ItemCode, custmer_code, facilityId
                    );
                return Result<decimal>.Sucess(list, "");
            }
            catch (Exception ex)
            {
                return Result<decimal>.Fail($"Exception: {ex.Message}");
            }

        }  
        
        
        [HttpGet("GetPriceDT")]

        public async Task<Result<decimal>> GetPriceDT(long listPrice, long itemId, long unitID)
        {
            try
            {
          
               

                decimal price = 0;

                foreach (DataRow rowPL in repository.GetPriceDT(itemId, unitID, listPrice).Rows)
                {
                    price = decimal.Parse(rowPL["Price"].ToString());
                }
                
                return Result<decimal>.Sucess(price, "");
            }
            catch (Exception ex)
            {
                return Result<decimal>.Fail($"Exception: {ex.Message}");
            }

        }

        [HttpGet(" ")]

        public async Task<Result<GetPriceItemVM>> GetPriceDTable(long listPrice, long itemId, long unitID)
        {
            try
            {



                GetPriceItemVM priceModel = new GetPriceItemVM();

                foreach (DataRow rowPL in repository.GetPriceDT(itemId, unitID, listPrice).Rows)
                {
                  //  price = decimal.Parse(rowPL["Price"].ToString());
                    priceModel = new GetPriceItemVM

                    {
                     price = decimal.Parse(rowPL["Price"].ToString()),
                     min_price = decimal.Parse(rowPL["Min_Price"].ToString()),
                     max_price = decimal.Parse(rowPL["Max_Price"].ToString()),

                         };

                }

                return Result<GetPriceItemVM>.Sucess(priceModel, "");
            }
            catch (Exception ex)
            {
                return Result<GetPriceItemVM>.Fail($"Exception: {ex.Message}");
            }

        }

        [HttpGet("chectItem")]
        public async Task<Result<bool>> ChectItem(long listPrice, string txtPrice, long itemId, long unitID)
        {
            try {

                if (listPrice > 0)
                {
                    if (await repository.CheckPriceIsBetween(itemId, unitID, listPrice, txtPrice) == 0)
                    {

                        return Result<bool>.Fail($" السعر المدخل خارج إطار السعر المحدد");
                     
                      


                }

                }
                if (await repository.CheckStatus(itemId) != 1)
                {

                    return Result<bool>.Fail($"الصنف الذي تم اختياره غير مفعل حالياً فضلاً تأكد من حالة الصنف");


                }


                return Result<bool>.Sucess(true,"");


            }
            catch (Exception ex) {
                return Result<bool>.Fail($"Exception: {ex.Message}");
            }

          

        }  
        //[HttpGet("GetPrice")]
        //public async Task<Result<bool>> GetPrice(long listPrice, long itemId, long unitID)
        //{
        //    try {

        //        if (listPrice > 0)
        //        { }


        //        return Result<bool>.Sucess(true,"");


        //    }
        //    catch (Exception ex) {
        //        return Result<bool>.Fail($"Exception: {ex.Message}");
        //    }

          

        //}

        [HttpGet("SAL_Items_Price_M")]

        public async Task<Result<List<SysLookupDataVM>>> SAL_Items_Price_M()
        {
            List < SysLookupDataVM > list = new List<SysLookupDataVM>();
            bool salePrice = true;
            bool lastSalePrice = true;
            bool purchaerPrice = false;
            try
            {

                if (!await HasPermissionProperty(106)) {

                    list.Add(new SysLookupDataVM
                    { CatagoriesId=0,
                        Code=-3,
                        Name= " سعر البيع ",
                        Name2= " سعر البيع"

                    });

                   
                }   if ( await HasPermissionProperty(105)) {

                    list.Add(new SysLookupDataVM
                    { CatagoriesId=0,
                        Code=-1,
                        Name= "آخر سعر للعميل",
                        Name2= "آخر سعر للعميل"

                    });

                   
                }   if (await HasPermissionProperty(14)) {

                    list.Add(new SysLookupDataVM
                    { CatagoriesId=0,
                        Code=-2,
                        Name= " سعر الشراء",
                        Name2= " سعر الشراء"

                    });

                   
                }
                var userID = long.Parse(User.FindFirst("USER_ID")?.Value);

              var list1 = await repository.SAL_Items_Price_M(userID);
                list.AddRange(list1);
                return Result< List<SysLookupDataVM>>.Sucess(list, "");
            }
            catch (Exception ex)
            {
                return Result<List<SysLookupDataVM>>.Fail($"Exception: {ex.Message}");
            }

        }
        private async Task<bool> HasPermissionProperty(int propertyId)
        {
            try
            {
                bool allow = false;

                var userId = int.Parse(User.FindFirst("USER_ID")?.Value);

                var getPerm = await sysScreenPermissionPropertiesVw.GetAll(d => d.UserId == userId & d.PropertyId == propertyId);
                if (getPerm == null)
                {
                    return false;
                }
                else
                {
                    var row = getPerm.FirstOrDefault();
                    if (row != null) { 
                    allow = row.Allow ?? false;
                    }
                }



                return allow;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // ***************  for test

        [HttpGet("GetItemsWithId")]
        public async Task<Result<GetItemByIdVM>> GetItemsById(long Item_No)
        {
            try
            {
              
                var getItem = await repository.GetAllOther<WhItemsVw>();
                var getItemWithId = getItem.FirstOrDefault(d=>d.Id == Item_No);
                if (getItemWithId == null)
                {
                    return Result<GetItemByIdVM>.Fail("no data found for this id ");
                }
                var itemById = new WhItemsVM
                {
                    Id = getItemWithId.Id,
                    ItemCode = getItemWithId.ItemCode,
                    ItemName = getItemWithId.ItemName,
                    PriceSale = getItemWithId.PriceSale,
                    PurchasePrice = getItemWithId.PurchasePrice,
                    UnitName = getItemWithId.UnitName,
                    VatRate = getItemWithId.VatRate,
                    CatName = getItemWithId.CatName,
                    UnitItemId = getItemWithId.UnitItemId,
                    VatEnable = getItemWithId.VatEnable,
                    PriceIncludeVat = getItemWithId.PriceIncludeVat,
                    CreatedOn = getItemWithId.CreatedOn
                };

                var transWithId = new GetItemByIdVM
                {
                    ItemsById = itemById,
                    SalePrice = 0,
                    DiscountRate = 0,
                   // VatAmount=0,
                    VaTAmount = 0,
                    VatRate = 0,

                };

                return Result<GetItemByIdVM>.Sucess(transWithId, "");

            }
            catch (Exception ex)
            {
                return Result<GetItemByIdVM>.Fail($"Exception: {ex.Message}");
            }
        }

        //*************** End ***********


        [HttpGet("GetItemsWithBarcode")]
        public async Task<Result<GetItemByIdVM>> GetItemsByBarcode(string barcode)
        {
            try
            {

                var getItem = await repository.GetAllOther<WhItemsVw>();
                var getItemWithId = getItem.FirstOrDefault(d => d.BarCode == barcode);
                if (getItemWithId == null)
                {
                    return Result<GetItemByIdVM>.Fail("no data found for this Item_Barcode ");
                }
                var itemById = new WhItemsVM
                {
                    Id = getItemWithId.Id,
                    ItemCode = getItemWithId.ItemCode,
                    ItemName = getItemWithId.ItemName,
                    PriceSale = getItemWithId.PriceSale,
                    PurchasePrice = getItemWithId.PurchasePrice,
                    UnitName = getItemWithId.UnitName,
                    VatRate = getItemWithId.VatRate,
                    CatName = getItemWithId.CatName,
                    UnitItemId = getItemWithId.UnitItemId,
                    VatEnable = getItemWithId.VatEnable,
                    PriceIncludeVat = getItemWithId.PriceIncludeVat,
                    CreatedOn = getItemWithId.CreatedOn,
                    BarCode = getItemWithId.BarCode,
                };

                var transWithId = new GetItemByIdVM
                {
                    ItemsById = itemById,
                    SalePrice = 0,
                    DiscountRate = 0,
                    // VatAmount=0,
                    VaTAmount = 0,
                    VatRate = 0,

                };

                return Result<GetItemByIdVM>.Sucess(transWithId, "");

            }
            catch (Exception ex)
            {
                return Result<GetItemByIdVM>.Fail($"Exception: {ex.Message}");
            }
        }

    }
   
}
