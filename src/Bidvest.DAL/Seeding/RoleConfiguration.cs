using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bidvest.DAL.Entities;

namespace Bidvest.DAL
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role { RoleId = 1, RoleName = "SystemAdmin" },new Role { RoleId = 2, RoleName = "User" });
        }
    }
}
