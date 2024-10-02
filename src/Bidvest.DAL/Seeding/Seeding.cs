using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.DAL
{
    public static class Seeding
    {
        public static void ConfigureModels(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
        }
    }
}
