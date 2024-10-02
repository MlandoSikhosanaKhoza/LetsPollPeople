using Bidvest.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.DAL
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
                new Status { StatusId = 1, StatusName = "Open", IsDefaultStatus = true, IsCompleteStatus = false },
                new Status { StatusId = 2, StatusName = "In Development", IsDefaultStatus = true, IsCompleteStatus = false },
                new Status { StatusId = 3, StatusName = "Awaiting Invoicing", IsDefaultStatus = true, IsCompleteStatus = false },
                new Status { StatusId = 4, StatusName = "Closed", IsDefaultStatus = true, IsCompleteStatus = true }
            );
        }
    }
}
