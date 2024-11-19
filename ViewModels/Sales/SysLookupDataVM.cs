using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class SysLookupDataVM
    {

        [StringLength(250)]
        public string? Name { get; set; }
        public string? Name2 { get; set; }

        
        public int? CatagoriesId { get; set; }

        public long? Code { get; set; }

    }  
}
