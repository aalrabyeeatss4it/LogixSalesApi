using System;
namespace LogixApi_v02.ViewModels
{
    public class MembersEntity
    {
        public string Member_ID { get; set; }
        public string ApiUrl { get; set; }
        public string ErpUrl { get; set; }
        public string DBName { get; set; }
        public string DBUsername { get; set; }
        public string DBPassword { get; set; }
        public string DBUrl { get; set; }




        public string ConnectionString { 
            get {
                if (string.IsNullOrEmpty(this.ErpUrl) || string.IsNullOrEmpty(this.DBName) 
                    || string.IsNullOrEmpty(this.DBUrl) || string.IsNullOrEmpty(this.DBUsername)
                    || string.IsNullOrEmpty(this.DBPassword))
                {
                    return "";
                }
                return $"server={DBUrl};database={DBName};User={DBUsername};Password={DBPassword};TrustServerCertificate=True;";
            } }

    }
}
