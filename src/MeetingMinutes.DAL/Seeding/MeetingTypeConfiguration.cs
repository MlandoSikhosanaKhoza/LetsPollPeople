using MeetingMinutes.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.DAL
{
    public class MeetingTypeConfiguration : IEntityTypeConfiguration<MeetingType>
    {
        public void Configure(EntityTypeBuilder<MeetingType> builder)
        {
            builder.HasData(
                new MeetingType { MeetingTypeId = 1, Code = "M", Name = "MANCO" }, 
                new MeetingType { MeetingTypeId = 2, Code = "F", Name = "Finance" }, 
                new MeetingType { MeetingTypeId = 3, Code = "PTL", Name = "Project Team Leaders" });
        }
    }
}
