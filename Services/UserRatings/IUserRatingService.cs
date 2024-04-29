using SurveysAssessment.Models;
using SurveysAssessment.ViewModels;

namespace SurveysAssessment.Services.UserRatings
{
    public interface IUserRatingService
    {
        public Task<List<UserActivityRatings>> GetAllRatings();

        public Task<UserActivityRatings> GetUserRatingsByUserId(int userId);

        public Task InsertOrUpdateUserRating(NewSurveyViewModel newSurveyViewModel);
    }
}
