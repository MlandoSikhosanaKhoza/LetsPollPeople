using MeetingMinutes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.BusinessLogic
{
    public interface IMeetingTypeLogic
    {
        MeetingTypeModel Create(MeetingTypeModel model);
        MeetingTypeModel Update(MeetingTypeModel model);
        MeetingTypeModel Delete(int meetingTypeId);
        IEnumerable<MeetingTypeModel> GetAll();
    }
}
