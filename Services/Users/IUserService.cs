using SurveysAssessment.Models;
using SurveysAssessment.ViewModels;

namespace SurveysAssessment.Services.Users
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();

        public Task<User> GetUserByEmail(string email);

        public Task<User> GetUserByUserId(int userId);

        public Task<int> GetUserIdByEmail(string email);

        public Task<int> CreateNewOrUpdateUser(NewSurveyViewModel surveyViewModel);
    }
}
