using LogixApi_v02.TestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SalPosCloseCashConfig : IEntityTypeConfiguration<SalPosCloseCash>
    {
        public void Configure(EntityTypeBuilder<SalPosCloseCash> entity)
        {
        entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

        entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
    }
    

}
