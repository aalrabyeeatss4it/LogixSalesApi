
using LogixApi_v02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs
{
    public class SysUserConfig : IEntityTypeConfiguration<SysUser>
    {
        public void Configure(EntityTypeBuilder<SysUser> entity)
        {
            entity.HasKey(e => e.UserId)
        .IsClustered(false);

            entity.HasIndex(e => e.UserId, "ID")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Enable).HasDefaultValueSql("((1))");

            entity.Property(e => e.IsAgree).HasDefaultValueSql("((0))");

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.Isupdate).HasDefaultValueSql("((0))");
        }
    }

}
