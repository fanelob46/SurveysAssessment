using SurveysAssessment.Models;
using SurveysAssessment.ViewModels;

namespace SurveysAssessment.Services.UserFavouriteFood
{
    public interface IUserFavouriteFoodService
    {
        public Task<List<UserFavouriteFoods>> GetAllFavouriteFoodsByUserId();

        public Task<UserFavouriteFoods> GetUserFavouriteFoodsByUserId(int userId);

        public Task InsertOrUpdateUserFavouriteFoods(NewSurveyViewModel surveyViewModel);
    }
}
