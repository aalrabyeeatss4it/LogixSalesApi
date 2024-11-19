using LogixApi_v02.TestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogixApi_v02.EntityConfigs
{
    public class AccFacilitiesVwConfig : IEntityTypeConfiguration<AccFacilitiesVw>
    {
        public void Configure(EntityTypeBuilder<AccFacilitiesVw> entity)
        {
            entity.ToView("ACC_Facilities_VW");
        }


    }

}
