using Microsoft.EntityFrameworkCore;
using SurveysAssessment.Data;
using SurveysAssessment.Models;
using SurveysAssessment.ViewModels;
using System.IO;

namespace SurveysAssessment.Services.UserFavouriteFood
{
    public class UserFavouriteFoodService : IUserFavouriteFoodService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserFavouriteFoodService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserFavouriteFoods>> GetAllFavouriteFoodsByUserId()
        {
            var allFavFoods = await _dbContext.UserFavouriteFoods.ToListAsync();

            return allFavFoods;
        }

        public async Task<UserFavouriteFoods> GetUserFavouriteFoodsByUserId(int userId)
        {
            var favFoods = await _dbContext.UserFavouriteFoods.FirstOrDefaultAsync(x => x.UserId == userId);

            return favFoods;
        }

        public async Task InsertOrUpdateUserFavouriteFoods(NewSurveyViewModel surveyViewModel)
        {
            if (surveyViewModel != null)
            {
                var userFavFoods = await GetUserFavouriteFoodsByUserId(surveyViewModel.UserId);
                if (userFavFoods == null)
                {
                    var newUserFoods = new UserFavouriteFoods
                    {
                        UserId = surveyViewModel.UserId,
                        SurveyId = surveyViewModel.SurveyId,
                        Pizza = surveyViewModel.Pizza,
                        Pasta = surveyViewModel.Pasta,
                        PapAndWors = surveyViewModel.PapAndWors,
                        Other = surveyViewModel.Other
                    };
                    _dbContext.Add(newUserFoods);
                }
                else
                {
                    userFavFoods.Pizza = surveyViewModel.Pizza;
                    userFavFoods.Pasta = surveyViewModel.Pasta;
                    userFavFoods.PapAndWors = surveyViewModel.PapAndWors;
                    userFavFoods.Other = surveyViewModel.Other;

                    _dbContext.Update(userFavFoods);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
