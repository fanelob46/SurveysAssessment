using Microsoft.EntityFrameworkCore;
using SurveysAssessment.Data;
using SurveysAssessment.Models;
using SurveysAssessment.ViewModels;

namespace SurveysAssessment.Services.UserRatings
{
    public class UserRatingService : IUserRatingService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRatingService(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserActivityRatings>> GetAllRatings()
        {
            var allRatings = await _dbContext.UserActivityRatings.ToListAsync();

            return allRatings;
        }

        public async Task<UserActivityRatings> GetUserRatingsByUserId(int userId)
        {
            var ratings = await _dbContext.UserActivityRatings.FirstOrDefaultAsync(x => x.UserId == userId);

            return ratings;
        }

        public async Task InsertOrUpdateUserRating(NewSurveyViewModel newSurveyViewModel)
        {
            if (newSurveyViewModel != null)
            {
                var userRating = await GetUserRatingsByUserId(newSurveyViewModel.UserId);
                if (userRating == null)
                {
                    var newRating = new UserActivityRatings
                    {
                        UserId = newSurveyViewModel.UserId,
                        SurveyId = newSurveyViewModel.SurveyId,
                        EatOut = newSurveyViewModel.EatOut,
                        ListenRadio = newSurveyViewModel.ListenRadio,
                        WatchMovies = newSurveyViewModel.WatchMovies,
                        WatchTV = newSurveyViewModel.WatchTV
                    };
                    _dbContext.Add(newRating);
                }
                else
                {
                    userRating.EatOut = newSurveyViewModel.EatOut;
                    userRating.ListenRadio = newSurveyViewModel.ListenRadio;
                    userRating.WatchMovies = newSurveyViewModel.WatchMovies;
                    userRating.WatchTV = newSurveyViewModel.WatchTV;

                    _dbContext.Update(userRating);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
