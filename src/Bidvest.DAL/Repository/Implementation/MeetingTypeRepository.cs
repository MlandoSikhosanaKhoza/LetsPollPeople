using Bidvest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.DAL.Repository
{
    public class MeetingTypeRepository : GenericRepository<MeetingType>, IMeetingTypeRepository
    {
        public MeetingTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override IEnumerable<MeetingType> GetAll()
        {
            return _dbSet.Where(mt => !mt.IsDeleted);
        }
    }
}
