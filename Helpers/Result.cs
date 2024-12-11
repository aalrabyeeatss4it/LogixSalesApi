using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels;
using LogixApi_v02.ViewModels.Sales;

namespace LogixApi_v02.Helpers
{
    public class Result<T>
    {
        public Result(bool isSuccess, T data = default, string msg = "", PaginationParams pagination = default)
        {
            Success = isSuccess;
            Data = data;
            Message = msg;
            Pagination = pagination;
        }

        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public PaginationParams? Pagination { get; set; }


        public static Result<T> Fail(string msg = "", string ex = null)
        {
            return new Result<T>(false, msg: msg);
        }

        public static Result<T> Sucess(T data, string msg = "", PaginationParams pagination = default)
        {
            return new Result<T>(true, data: data, msg: msg, pagination: pagination);
        }

        internal static Result<IEnumerable<SysLookupData>> Sucess(IEnumerable<SysLookupDataVw> customerActivityList, string v)
        {
            throw new NotImplementedException();
        }
    }



        public class ResultPagination<T>
    {
        public ResultPagination(bool isSuccess, Pagination pagination = default ,T data = default, string msg = "")
        {
            Success = isSuccess;
            Data = data;
            Message = msg;
          
            Pagination = pagination;
        }

        public bool Success { get; set; }
        public Pagination Pagination { get; set; }
        public T Data { get; set; }
  
        public string Message { get; set; }


        public static ResultPagination<T> Fail(string msg = "")
        {
            return new ResultPagination<T>(false, msg: msg);
        }

        public static ResultPagination<T> Sucess(Pagination pagination, T data, string msg = "")
        {
            return new ResultPagination<T>(true, pagination:pagination, data: data, msg: msg);
        }

      
    }
}
