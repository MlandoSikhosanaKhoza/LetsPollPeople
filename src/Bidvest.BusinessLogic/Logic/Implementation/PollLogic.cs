using AutoMapper;
using Bidvest.DAL.Repository;
using Bidvest.DAL.Entities;
using Bidvest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bidvest.DAL;
using Bidvest.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Bidvest.BusinessLogic
{
    public class PollLogic : IPollLogic
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserVoteRepository _userVoteRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PollLogic(IQuestionRepository questionRepository, IUserVoteRepository userVoteRepository, IMapper mapper, 
            IUserRepository userRepository, IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _userVoteRepository = userVoteRepository;
            _mapper             = mapper;
            _userRepository     = userRepository;
            _contextAccessor    = contextAccessor;
            _unitOfWork         = unitOfWork;
        }


        /// <summary>
        /// Get the question so that the user can vote
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public QuestionModel GetQuestionById(int questionId)
        {
            Question? question           = _questionRepository.GetById(questionId);
            QuestionModel? questionModel = _mapper.Map<QuestionModel>(question);
            return questionModel;
        }

        /// <summary>
        /// Get all polling questions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<QuestionModel> GetQuestions()
        {
            IEnumerable<QuestionModel> pollResults = _questionRepository.GetAll().Select(_mapper.Map<QuestionModel>);
            return pollResults;
        }

        /// <summary>
        /// Add new question for polling
        /// </summary>
        /// <param name="questionModel"></param>
        /// <returns></returns>
        public QuestionModel CreateQuestion(QuestionModel questionModel)
        {
            //Get the user from the token
            User user         = GetCurrentUser();

            //Throw an exception for less than 2 options
            //This can hurt the polling results
            if (questionModel.Options.Count() < 2)
            {
                throw new DataMisalignedException("At least 2 options need to be entered. Data integrity is at risk.");
            }

            //Ensure that the author of the question is marked inside the question
            Question question = _mapper.Map<Question>(questionModel);
            question.UserId   = user.UserId;

            //Add and persist the user
            _questionRepository.Insert(question);
            _unitOfWork.SaveChanges();

            return _mapper.Map<QuestionModel>(question);
        }

        /// <summary>
        /// A ballot for the option to submit
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="optionId"></param>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataMisalignedException"></exception>
        public void Vote(int questionId, int optionId)
        {
            User user = GetCurrentUser();
            
            //Check if the question even exists
            Question? question = _questionRepository.GetById(questionId);
            //Throw an exception for the imaginary question
            if (question == null)
            {
                throw new ArgumentNullException("Question Id doesn't exist");
            }

            /* Check that the option matches with the question
             * Throw an exception for mismatched options */
            if(!question.Options.Any(o=> o.OptionId == optionId))
            {
                throw new DataMisalignedException("Option Id doesn't correlate to the Question Id");
            }
            
            //Check if the user has voted already
            UserVote? userVote = _userVoteRepository.GetUserVote(questionId, user.UserId);
            if (userVote == null)
            {
                //Add the vote if the user hasn't voted yet
                _userVoteRepository.Insert(new UserVote { UserId = user.UserId, QuestionId = questionId, OptionId = optionId });
            }
            else
            {
                //Update the option if the user did vote
                userVote.OptionId = optionId;
                _userVoteRepository.Update(userVote);
            }

            //Persist any changes
            _unitOfWork.SaveChanges();
        }
        
        /// <summary>
        /// Get the current user from the JWT Token
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        private User GetCurrentUser()
        {
            // Find the current user of the vote 
            string? username = JwtTokenHelper.GetTokenValue(_contextAccessor, ClaimTypes.NameIdentifier);
            User? user = _userRepository.Get(u => u.Username.ToLower() == username).FirstOrDefault();

            /** Check if the user exists in the database
            *   Throw an exception to prevent a potentially corrupt token from voting */
            if (user == null)
            {
                throw new UnauthorizedAccessException("Username seems to not exist for user");
            }
            return user;
        }
    }
}
