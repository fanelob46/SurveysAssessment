using SurveysAssessment.Data;
using SurveysAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using SurveysAssessment.ViewModels;
using Microsoft.EntityFrameworkCore;
using SurveysAssessment.Services.Users;
using SurveysAssessment.Services.UserRatings;
using SurveysAssessment.Services.UserFavouriteFood;
using SurveysAssessment.Services.SurveyService;
using SurveysAssessment.Helpers;

namespace SurveysAssessment.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserService _users;
        private readonly ISurveyService _surveys;
        private readonly IUserRatingService _ratings;
        private readonly IUserFavouriteFoodService _favFoods;

        public SurveyController(ApplicationDbContext dbContext, IUserService users, ISurveyService surveys, IUserRatingService ratings, IUserFavouriteFoodService favFoods)
        {
            _dbContext = dbContext;
            _surveys = surveys;
            _users = users;
            _ratings = ratings;
            _favFoods = favFoods;
        }

        [HttpGet]
        public IActionResult NewSurvey()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewSurvey(NewSurveyViewModel surveyViewModel)
        {
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            try
            {
                surveyViewModel.UserId = await _users.CreateNewOrUpdateUser(surveyViewModel);
                surveyViewModel.SurveyId = await _surveys.InsertNewSurvey(surveyViewModel.UserId);

                await _ratings.InsertOrUpdateUserRating(surveyViewModel);
                await _favFoods.InsertOrUpdateUserFavouriteFoods(surveyViewModel);

                await transaction.CommitAsync();

                return Ok();
            }
            catch
            {
                await transaction.RollbackAsync();

                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> SurveyResults()
        {
            var allUsers = await _users.GetAllUsers();
            allUsers = allUsers.OrderBy(u => u.DateOfBirth).ToList();

            var surveyResult = new SurveyResultsViewModel();

            if (allUsers != null && allUsers.Count > 0)
            {
                var totalSurveys = await _surveys.GetAllSurveys();

                var average = allUsers.Sum(u => HelperFunctions.GetUserAge(u)) / allUsers.Count;
                var oldestAge = HelperFunctions.GetUserAge(allUsers.FirstOrDefault());
                var youngestAge = HelperFunctions.GetUserAge(allUsers.LastOrDefault());

                var allFavFoods = await _favFoods.GetAllFavouriteFoodsByUserId();
                var allRatings = await _ratings.GetAllRatings();

                surveyResult = new SurveyResultsViewModel
                {
                    TotalSurveys = totalSurveys.Count,
                    AverageAge = average,
                    OldestAgeInSurvey = oldestAge,
                    YoungestAgeInSurvey = youngestAge,

                    LikePizzaPercent = HelperFunctions.GetPercentageOfLikePizza(allFavFoods),
                    LikePastaPercent = HelperFunctions.GetPercentageOfLikePasta(allFavFoods),
                    LikePapAndWorsPercent = HelperFunctions.GetPercentageOfLikePapAndWors(allFavFoods),

                    WatchMoviesAverage = HelperFunctions.GetAverageOfWatchMovies(allRatings),
                    ListenRadioAverage = HelperFunctions.GetAverageOfListenRadio(allRatings),
                    LikeEatOutAverage = HelperFunctions.GetAverageOfEatOut(allRatings),
                    WatchTVAverage = HelperFunctions.GetAverageOfWatchTV(allRatings),
                };
            }
            return View(surveyResult);
        }
    }
}
