
using LogixApi_v02.DbContexts;
using LogixApi_v02.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Helpers
{
    public class GetConnectionString
    {


        private static async Task<MembersEntity?> GetConctionString(ApplicationDbContext _context, string memberId)
        {
            try
            {
                var mobileMember = await _context.SysMobileMembers.SingleOrDefaultAsync(s => s.MemberId == memberId && s.IsDeleted == false);
                if (mobileMember != null)
                {
                    var member = new MembersEntity
                    {
                        ApiUrl = mobileMember.ApiUrl ?? "",
                        DBName = mobileMember.Dbname ?? "",
                        DBPassword = mobileMember.Dbpassword ?? "",
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
