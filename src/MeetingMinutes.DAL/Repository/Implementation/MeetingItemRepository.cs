using MeetingMinutes.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.DAL.Repository
{
    public class MeetingItemRepository : GenericRepository<MeetingItem>, IMeetingItemRepository
    {
        public MeetingItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public IEnumerable<MeetingItem> GetByMeeting(int meetingId)
        //{
        //    return _dbSet.Include(mi => mi.ActionByNavigation)
        //        .Include(mi => mi.Item).ThenInclude(i => i.Actions)
        //        .Include(mi => mi.ItemStatus).ThenInclude(i => i.Status)
        //        .Where(mi => mi.MeetingId == meetingId);
        //}

        public IEnumerable<MeetingItem> GetByMeetingType(int meetingTypeId)
        {
            return _dbSet.Include(mi => mi.Meeting)
                .Include(mi => mi.Item).ThenInclude(i => i.Actions)
                .Where(mi => mi.Meeting.MeetingTypeId == meetingTypeId)
                .OrderByDescending(mi => mi.Meeting.ScheduleStartDateTime);
        }

        //public IEnumerable<MeetingItem> GetTodoByMeetingType(int meetingTypeId)
        //{
        //    return _dbSet.Include(mi => mi.Meeting)
        //        .Include(mi => mi.Item).ThenInclude(i => i.Actions)
        //        .Where(mi => mi.Meeting.MeetingTypeId == meetingTypeId)
        //        .OrderByDescending(mi => mi.Meeting.ScheduleStartDateTime);
        //}

        //public IEnumerable<MeetingItem> GetCompletedByMeetingType(int meetingTypeId)
        //{
        //    return _dbSet.Include(mi => mi.Meeting)
        //        .Include(mi => mi.Item).ThenInclude(i => i.Actions)
        //        .Where(mi => mi.Meeting.MeetingTypeId == meetingTypeId)
        //        .OrderByDescending(mi => mi.Meeting.ScheduleStartDateTime);
        //}
    }
}
