using Bidvest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.BusinessLogic
{
    public interface IMeetingLogic
    {
        MeetingModel Create(MeetingModel model);
        MeetingModel Update(MeetingModel model);
        MeetingModel Delete(int meetingId);
        IEnumerable<MeetingModel> GetAll();
        MeetingModel GetById(int meetingId);
    }
}
