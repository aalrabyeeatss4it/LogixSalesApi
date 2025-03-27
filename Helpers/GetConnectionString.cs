
using LogixApi_v02.DbContexts;
using LogixApi_v02.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace LogixApi_v02.Helpers
{
    public class GetConnectionString
    {
        private static string Decrypt(string encryptedValue)
        {
            try
            {

                var config = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                 .Build();


                var key = config["AppSettings:EncryptionKey"];

                if (string.IsNullOrEmpty(key))
                {
                    throw new Exception("لم يتم الحصول على المفتاح من إعدادات التطبيق.");
                }

                using (var aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
                    aes.IV = new byte[16];

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        var encryptedBytes = Convert.FromBase64String(encryptedValue);
                        var decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                        return Encoding.UTF8.GetString(decryptedBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطأ أثناء فك التشفير: {ex.Message}");
                return null;
            }
        }

        public static string Encrypt(string plainText)
        {
            try
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var key = config["AppSettings:EncryptionKey"];
                if (string.IsNullOrEmpty(key))
                {
                    throw new Exception("لم يتم الحصول على المفتاح من إعدادات التطبيق.");
                }
                using (var aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
                    aes.IV = new byte[16];
                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    {
                        var plainBytes = Encoding.UTF8.GetBytes(plainText);
                        var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                        return Convert.ToBase64String(encryptedBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطأ أثناء فك التشفير: {ex.Message}");
                return null;
            }
        }
        private static async Task<MembersEntity?> GetConctionString(ApplicationDbContext _context, string memberId)
        {
            try
            {
                Console.WriteLine("_context.Database.GetConnectionString:" + _context.Database.GetConnectionString());
                var mobileMember = await _context.SysMobileMembers.SingleOrDefaultAsync(s => s.MemberId == memberId && s.IsDeleted == false);
                if (mobileMember != null)
                {
                    var member = new MembersEntity
                    {
                        ApiUrl = mobileMember.ApiUrl ?? "",
                        DBName = mobileMember.Dbname ?? "",
                        //DBPassword = Encrypt(mobileMember.Dbpassword) ?? "", // فك تشفير DBPassword
                        DBPassword = Decrypt(mobileMember.Dbpassword) ?? "", // فك تشفير DBPassword
                        DBUrl = mobileMember.Dburl ?? "",
                        DBUsername = mobileMember.Dbusername ?? "",
                        ErpUrl = mobileMember.ErpUrl ?? "",
                        Member_ID = mobileMember.MemberId ?? ""
                    };

                    return member;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<string> GetconnactionstringByMember(ApplicationDbContext _context, string memberId)
        {
            var member = await GetConctionString(_context, memberId);
            return member.ConnectionString;

        }
    }
}
