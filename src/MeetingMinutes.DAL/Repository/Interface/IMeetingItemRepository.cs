using MeetingMinutes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.DAL.Repository
{
    public interface IMeetingItemRepository : IGenericRepository<MeetingItem>
    {
        //IEnumerable<MeetingItem> GetByMeeting(int meetingId);
        IEnumerable<MeetingItem> GetByMeetingType(int meetingTypeId);
    }
}
