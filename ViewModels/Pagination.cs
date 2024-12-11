using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogixApi_v02.ViewModels
{
    //public class Pagination
    //{
    //    public int Size { get; set; }
    //    public int Count{ get; set; }
    //    public int CurrentPage{ get; set; }
    //    public int NextPage{ get; set; }
    //    public bool HasNext{ get; set; }
    //    public Pagination(int page, int count, int size)
    //    {

    //        size = (size < 1) ? 1 : size;
    //        size = (size > 25) ? 25 : size;
    //        Size = size;


    //        double r = (Convert.ToDouble( count )/ Convert.ToDouble(size));
    //        Count = Convert.ToInt32(Math.Ceiling(r));


    //        page = (page <= 0) ? 1 : page;
    //        page = (page > count) ? count : page;
    //        CurrentPage = page;
    //        HasNext = CurrentPage < Count+1 ? true : false;
    //        NextPage = page+1;
    //    }

    //}

    public class Pagination
    {
        public int Size { get; set; }

        public int Count { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (Count / Size) + (Count % Size > 0 ? 1 : 0);

        public bool HasNextPage => TotalPages > CurrentPage && CurrentPage > 0;

        public bool HasPreviousPage => CurrentPage > 1;



        public int NextPage => HasNextPage ? (CurrentPage + 1) : 0;

        public int PreviousPage => HasPreviousPage ? CurrentPage - 1 : 0;

        public Pagination(int page, int count, int size)
        {
            CurrentPage = page;
            Count = count;
            Size = size;
        }

    }
}
