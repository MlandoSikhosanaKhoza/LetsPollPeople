using MeetingMinutes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.BusinessLogic
{
    public interface IPollLogic
    {
        /// <summary>
        /// Get the question so that the user can vote
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        QuestionModel GetQuestionById(int questionId);

        /// <summary>
        /// Get all polling questions
        /// </summary>
        /// <returns></returns>
        IEnumerable<QuestionModel> GetQuestions();

        /// <summary>
        /// Add new question for polling
        /// </summary>
        /// <param name="questionModel"></param>
        /// <returns></returns>
        QuestionModel CreateQuestion(QuestionModel questionModel);

        /// <summary>
        /// A ballot for the option to submit
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="optionId"></param>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataMisalignedException"></exception>
        void Vote(int questionId, int optionId);
    }
}
