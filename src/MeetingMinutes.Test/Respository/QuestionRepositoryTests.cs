using FluentAssertions;
using MeetingMinutes.DAL;
using MeetingMinutes.DAL.Entities;
using MeetingMinutes.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Test.Respository
{
    public class QuestionRepositoryTests
    {
        //SUT
        private readonly IQuestionRepository _questionRepository;
        private readonly ApplicationDbContext _dbContext;
        public QuestionRepositoryTests()
        {
            _dbContext             = GetDbContext().GetAwaiter().GetResult();
            IUnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            _questionRepository    = new QuestionRepository(_dbContext);
        }
        //This is the same across all repositories
        #region DBContext Setup
        private async Task<ApplicationDbContext> GetDbContext()
        {
            //Repositories will be tested using in memory databases
            var options         = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();

            //Initialize roles
            Role sysAdminRole = new Role { RoleName = "SystemAdmin" };
            Role userRole     = new Role { RoleName = "User"        };

            //Initialise users
            User user1 = new User
            {
                Username  = "Mlando",
                Password  = "75ee8d4458dea85b62bda80306c89aa859d4903660de735e6d96b74cab411f97",
                FirstName = "Mlando",
                LastName  = "Sikhosana Khoza",
                IsActive  = true
            };
            User user2 = new User
            {
                Username  = "Areezy",
                Password  = "75ee8d4458dea85b62bda80306c89aa859d4903660de735e6d96b74cab411f97",
                FirstName = "Arron",
                LastName  = "Mazel",
                IsActive  = true
            };

            //Ask the question
            Question question1 = new Question { 
                QuestionText   = "Which is your preferred flavour of ice-cream?",
                User           = user1,
            };
            //Append options
            question1.Options.Add(new Option { OptionText = "Rocky road" });
            question1.Options.Add(new Option { OptionText = "Caramel"    });
            question1.Options.Add(new Option { OptionText = "Vanilla"    });
            question1.Options.Add(new Option { OptionText = "Strawberry" });
            //Ask the question
            Question question2 = new Question
            {
                QuestionText = "Which food do you prefer?",
                User         = user1
            };
            //Append options
            question2.Options.Add(new Option { OptionText = "Hot Dog" });
            question2.Options.Add(new Option { OptionText = "Burger"  });
            question2.Options.Add(new Option { OptionText = "Pizza"   });

            if (await databaseContext.Roles.CountAsync() == 0)
            {
                await databaseContext.Roles.AddAsync(sysAdminRole);
                await databaseContext.Roles.AddAsync(userRole);
                await databaseContext.SaveChangesAsync();
            }

            if (await databaseContext.Users.CountAsync() == 0)
            {

                await databaseContext.Users.AddAsync(user1);
                await databaseContext.Users.AddAsync(user2);

                await databaseContext.SaveChangesAsync();
                
                user1.UserRoles.Add(new UserRole { UserId = user1.UserId, RoleId = userRole.RoleId });
                databaseContext.Users.Update(user1);

                await databaseContext.SaveChangesAsync();
            }

            if (await databaseContext.Questions.CountAsync() == 0)
            {
                await databaseContext.Questions.AddAsync(question1);
                await databaseContext.Questions.AddAsync(question2);
                await databaseContext.SaveChangesAsync();
            }
            //Question 1
            //The number represents the person choosing it
            Option chosenOptionStrawberry1 = question1.Options.First(o => o.OptionText == "Strawberry");
            Option chosenOptionStrawberry2 = question1.Options.First(o => o.OptionText == "Strawberry");

            //Question 2
            //The number represents the person choosing it
            Option chosenOptionHotdog1 = question2.Options.First(o => o.OptionText == "Hot Dog");
            Option chosenOptionPizza2  = question2.Options.First(o => o.OptionText == "Pizza"  );

            if(await databaseContext.UserVotes.CountAsync() == 0)
            {
                //Question 1
                await databaseContext.UserVotes.AddAsync(new UserVote { UserId = user1.UserId, QuestionId = question1.QuestionId, OptionId = chosenOptionStrawberry1.OptionId });
                await databaseContext.UserVotes.AddAsync(new UserVote { UserId = user2.UserId, QuestionId = question1.QuestionId, OptionId = chosenOptionStrawberry2.OptionId });

                //Question 2
                await databaseContext.UserVotes.AddAsync(new UserVote { UserId = user1.UserId, QuestionId = question2.QuestionId, OptionId = chosenOptionHotdog1.OptionId });
                await databaseContext.UserVotes.AddAsync(new UserVote { UserId = user2.UserId, QuestionId = question2.QuestionId, OptionId = chosenOptionPizza2.OptionId  });
                await databaseContext.SaveChangesAsync();
            }

            return databaseContext;
        }
        #endregion DBContext Setup

        [Fact]
        public void QuestionRepository_GetQuestions_ReturnCount()
        {
            //Arrange
            int count = 0;

            //Act
            IEnumerable<Question> questions = _questionRepository.GetAll();
            count                           = questions.Count();

            //Assert
            count.Should().Be(2);
        }

        [Fact]
        public void QuestionRepository_GetQuestions_IncludesOptions()
        {
            //Arrange
            int count = 0;

            //Act
            IEnumerable<Question> questions = _questionRepository.GetAll();
            count                           = questions.First().Options.Count();

            //Assert
            count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void QuestionRepository_GetByUser_FirstUserHas2Questions()
        {
            //Arrange
            int count = 0;

            //Act
            IEnumerable<Question> questions = _questionRepository.GetByUser(1);
            count                           = questions.Count();

            //Assert
            count.Should().Be(2);
        }
        
        [Fact]
        public void QuestionRepository_GetByUser_SecondUserHas0Questions()
        {
            //Arrange
            int count = 0;

            //Act
            IEnumerable<Question> questions = _questionRepository.GetByUser(2);
            count                           = questions.Count();

            //Assert
            count.Should().Be(0);
        }

        [Fact]
        public void QuestionRepository_GetById_ShouldAskIcecream()
        {
            //Arrange
            string output = "";

            //Act
            Question? question = _questionRepository.GetById(1);
            output             = question?.QuestionText??"";
            //Assert
            output.Should().Be("Which is your preferred flavour of ice-cream?");
        }
    }
}
