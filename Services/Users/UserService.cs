using Microsoft.EntityFrameworkCore;
using SurveysAssessment.Data;
using SurveysAssessment.Models;
using SurveysAssessment.ViewModels;

namespace SurveysAssessment.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await _dbContext.Users.ToListAsync();
            
            return allUsers;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<User> GetUserByUserId(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);

            return user;
        }

        public async Task<int> GetUserIdByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            return user?.UserId ?? -1;
        }

        public async Task<int> CreateNewOrUpdateUser(NewSurveyViewModel surveyViewModel)
        {
            if (surveyViewModel != null)
            {
                var userId = await GetUserIdByEmail(surveyViewModel.Email);
                User user = null;
                if (userId == -1)  //Insert New
                {
                    user = new User
                    {
                        FullName = surveyViewModel.FullName,
                        Email = surveyViewModel.Email,
                        ContactNumber = surveyViewModel.ContactNumber,
                        DateOfBirth = surveyViewModel.DateOfBirth
                    };
                    _dbContext.Add(user);
                }
                else  // Update Existing
                {
                    user = await GetUserByEmail(surveyViewModel.Email);
                    user.FullName = surveyViewModel.FullName;
                    user.ContactNumber = surveyViewModel.ContactNumber;
                    user.DateOfBirth = surveyViewModel.DateOfBirth;

                    _dbContext.Update(user);
                }

                await _dbContext.SaveChangesAsync();

                return user.UserId;
            }
            return -1;
        }
    }
}
