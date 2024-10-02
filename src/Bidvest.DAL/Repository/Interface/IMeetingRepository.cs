using Bidvest.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.DAL.Repository
{
    public interface IMeetingRepository : IGenericRepository<Meeting>
    {
        Meeting? GetById(int meetingId);
        Meeting? GetPreviousByMeetingType(int meetingTypeId, DateTime currentDate);
    }
}
