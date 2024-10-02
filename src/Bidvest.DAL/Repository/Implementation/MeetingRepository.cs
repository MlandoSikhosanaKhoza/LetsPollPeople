using Bidvest.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.DAL.Repository
{
    public class MeetingRepository : GenericRepository<Meeting>, IMeetingRepository
    {
        public MeetingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override IEnumerable<Meeting> GetAll()
        {
            return _dbSet.Include(m => m.MeetingType).Where(m => !m.IsDeleted);
        }

        public Meeting? GetById(int meetingId)
        {
            return UseStandardQuery().FirstOrDefault(m => m.MeetingId == meetingId);
        }

        public Meeting? GetPreviousByMeetingType(int meetingTypeId, DateTime currentDate)
        {
            return UseStandardQuery()
                .Where(mi => mi.MeetingTypeId == meetingTypeId && mi.ScheduleStartDateTime < currentDate)
                .OrderByDescending(mi => mi.ScheduleStartDateTime).FirstOrDefault();
        }
        /// <summary>
        /// Add a meeting. Please note the meeting expects a meeting type object as well as the meeting type id
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        public override Meeting Insert(Meeting meeting)
        {
            meeting.SequenceNo  = -1;
            meeting.Code        = $"";
            meeting.DateCreated = DateTime.Now;
            return base.Insert(meeting);
        }

        private IQueryable<Meeting> UseStandardQuery()
        {
            return _dbSet.Include(m => m.MeetingItems).ThenInclude(mi => mi.Item).ThenInclude(i => i.Actions);
        }
    }
}
