using Microsoft.EntityFrameworkCore;
using SurveysAssessment.Data;
using SurveysAssessment.Models;

namespace SurveysAssessment.Services.SurveyService
{
    public class SurveyService : ISurveyService
    {
        private readonly ApplicationDbContext _dbContext;

        public SurveyService(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Survey>> GetAllSurveys()
        {
            var allSurveys = await _dbContext.Surveys.ToListAsync();

            return allSurveys;
        }

        public async Task<Survey> GetSurveyByUserId(int userId)
        {
            var userSurvey = await _dbContext.Surveys.FirstOrDefaultAsync(x => x.UserId == userId);

            return userSurvey;
        }

        public async Task<int> InsertNewSurvey(int userId)
        {
            var userSurvey = await GetSurveyByUserId(userId);
            if (userSurvey == null)
            {
                var newSurvey = new Survey
                {
                    UserId = userId
                };
                _dbContext.Add(newSurvey);
                await _dbContext.SaveChangesAsync();

                return newSurvey.SurveyId;
            }
            return userSurvey.SurveyId;
        }
    }
}
