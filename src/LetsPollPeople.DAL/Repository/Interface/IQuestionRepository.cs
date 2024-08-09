using LetsPollPeople.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.DAL.Repository
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        /// <summary>
        /// Get all questions
        /// </summary>
        /// <returns></returns>
        new IEnumerable<Question> GetAll();

        /// <summary>
        /// Get All questions that were created by the user
        /// This is if the user wants to edit his polls
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Question> GetByUser(int userId);

        /// <summary>
        /// Get only one question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Question? GetById(int id);
    }
}
