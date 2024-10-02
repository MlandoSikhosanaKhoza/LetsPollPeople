using Bidvest.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.DAL.Repository
{
    /// <summary>
    /// This is used to track the polling and ansers of users
    /// </summary>
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }
        /// <summary>
        /// Used to include all the entities within question
        /// </summary>
        /// <returns></returns>
        private IQueryable<Question> UseStandardQuery()
        {
            return _dbSet
                .Include(q => q.User) /* Author of the question */
                .Include(q => q.Options).ThenInclude(o => o.UserVotes); /* Options as well as the votes */
        }

        /// <summary>
        /// Get all questions
        /// </summary>
        /// <returns></returns>
        public new IEnumerable<Question> GetAll()
        {
            return UseStandardQuery();
        }

        /// <summary>
        /// Get All questions that were created by the user
        /// This is if the user wants to edit his polls
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Question> GetByUser(int userId) { 
            return UseStandardQuery().Where(q=> q.UserId == userId);
        }

        /// <summary>
        /// Get only one question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Question? GetById(int id) {
            return UseStandardQuery().FirstOrDefault(q => q.QuestionId == id);
        }
    }
}
