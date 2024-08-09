using LetsPollPeople.DAL.Entities;
using LetsPollPeople.DAL.Repository;
using LetsPollPeople.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace LetsPollPeople.Test.Respository
{
    public class UserVoteRepositoryTests
    {
        //SUT
        private readonly IUserVoteRepository _userVoteRepository;
        private readonly ApplicationDbContext _dbContext;
        public UserVoteRepositoryTests()
        {
            _dbContext             = GetDbContext().GetAwaiter().GetResult();
            IUnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            _userVoteRepository    = new UserVoteRepository(_dbContext);
        }
        //This is the same across all repositories
        #region DBContext Setup
        private async Task<ApplicationDbContext> GetDbContext()
        {
            //Repositories will be tested using in memory databases
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();

            //Initialize roles
            Role sysAdminRole = new Role { RoleName = "SystemAdmin" };
            Role userRole = new Role { RoleName = "User" };

            //Initialise users
            User user1 = new User
            {
                Username = "Mlando",
                Password = "75ee8d4458dea85b62bda80306c89aa859d4903660de735e6d96b74cab411f97",
                FirstName = "Mlando",
                LastName = "Sikhosana Khoza",
                IsActive = true
            };
            User user2 = new User
            {
                Username = "Areezy",
                Password = "75ee8d4458dea85b62bda80306c89aa859d4903660de735e6d96b74cab411f97",
                FirstName = "Arron",
                LastName = "Mazel",
                IsActive = true
            };

            //Ask the question
            Question question1 = new Question
            {
                QuestionText = "Which is your preferred flavour of ice-cream?",
                User = user1,
            };
            //Append options
            question1.Option.Add(new Option { OptionText = "Rocky road" });
            question1.Option.Add(new Option { OptionText = "Caramel" });
            question1.Option.Add(new Option { OptionText = "Vanilla" });
            question1.Option.Add(new Option { OptionText = "Strawberry" });
            //Ask the question
            Question question2 = new Question
            {
                QuestionText = "Which food do you prefer?",
                User = user1
            };
            //Append options
            question2.Option.Add(new Option { OptionText = "Hot Dog" });
            question2.Option.Add(new Option { OptionText = "Burger" });
            question2.Option.Add(new Option { OptionText = "Pizza" });

            if (await databaseContext.Role.CountAsync() == 0)
            {
                await databaseContext.Role.AddAsync(sysAdminRole);
                await databaseContext.Role.AddAsync(userRole);
                await databaseContext.SaveChangesAsync();
            }

            if (await databaseContext.User.CountAsync() == 0)
            {

                await databaseContext.User.AddAsync(user1);
                await databaseContext.User.AddAsync(user2);
                await databaseContext.SaveChangesAsync();

                user1.UserRole.Add(new UserRole { UserId = user1.UserId, RoleId = userRole.RoleId });
                databaseContext.User.Update(user1);

                await databaseContext.SaveChangesAsync();
            }

            if (await databaseContext.Question.CountAsync() == 0)
            {
                await databaseContext.Question.AddAsync(question1);
                await databaseContext.Question.AddAsync(question2);
                await databaseContext.SaveChangesAsync();
            }
            //Question 1
            //The number represents the person choosing it
            Option chosenOptionStrawberry1 = question1.Option.First(o => o.OptionText == "Strawberry");
            Option chosenOptionStrawberry2 = question1.Option.First(o => o.OptionText == "Strawberry");

            //Question 2
            //The number represents the person choosing it
            Option chosenOptionHotdog1 = question2.Option.First(o => o.OptionText == "Hot Dog");
            Option chosenOptionPizza2  = question2.Option.First(o => o.OptionText == "Pizza");

            if (await databaseContext.UserVote.CountAsync() == 0)
            {
                //Question 1
                await databaseContext.UserVote.AddAsync(new UserVote { UserId = user1.UserId, QuestionId = question1.QuestionId, OptionId = chosenOptionStrawberry1.OptionId });
                await databaseContext.UserVote.AddAsync(new UserVote { UserId = user2.UserId, QuestionId = question1.QuestionId, OptionId = chosenOptionStrawberry2.OptionId });

                //Question 2
                await databaseContext.UserVote.AddAsync(new UserVote { UserId = user1.UserId, QuestionId = question2.QuestionId, OptionId = chosenOptionHotdog1.OptionId });
                await databaseContext.UserVote.AddAsync(new UserVote { UserId = user2.UserId, QuestionId = question2.QuestionId, OptionId = chosenOptionPizza2.OptionId });
                await databaseContext.SaveChangesAsync();
            }

            return databaseContext;
        }
        #endregion DBContext Setup


        //GetUserVote
        [Fact]
        public void UserVoteRepository_GetUserVote_ShouldHaveOptionStrawberry()
        {
            //Arrange
            string output = "";

            //Act
            UserVote userVote = _userVoteRepository.GetUserVote( 1 , 1 ) ?? new UserVote();
            output = _dbContext.Option.First(o => o.OptionId == userVote.OptionId).OptionText;
            //Assert
            output.Should().Be("Strawberry");
        }

        [Theory]
        [InlineData(1,1,false)]
        [InlineData(3,1,true)]
        [InlineData(2,2,false)]
        public void UserVoteRepository_GetUserVote_OutputIsNull(int questionId,int userId,bool expected)
        {
            //Act
            UserVote? userVote = _userVoteRepository.GetUserVote(questionId, userId);
            //Assert
            if(expected)
            {
                userVote.Should().BeNull();
            }
            else
            {
                userVote.Should().NotBeNull();
            }
        }
    }
}
