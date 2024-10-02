using MeetingMinutes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.BusinessLogic
{
    public interface IStatusLogic
    {
        StatusModel Create(StatusModel model);
        StatusModel Update(StatusModel model);
        StatusModel Delete(int StatusId);
        IEnumerable<StatusModel> GetAll();
    }
}
