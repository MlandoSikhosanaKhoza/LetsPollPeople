using MeetingMinutes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.DAL.Repository
{
    public interface IUserVoteRepository : IGenericRepository<UserVote>
    {
        /// <summary>
        /// Find the users vote for a specific question (only one answer should be allowed)
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserVote? GetUserVote(int questionId, int userId);
    }
}
