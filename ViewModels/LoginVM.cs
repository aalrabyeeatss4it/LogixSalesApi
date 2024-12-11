using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels
{
    public class LoginVM
    {

        public string? UserName { get; set; } 
        
        public string? Password { get; set; } 

        public string? MemberId { get; set; }
    }
}
