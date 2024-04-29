using SurveysAssessment.Models;

namespace SurveysAssessment.Services.SurveyService
{
    public interface ISurveyService
    {
        public Task<List<Survey>> GetAllSurveys();

        public Task<Survey> GetSurveyByUserId(int userId);

        public Task<int> InsertNewSurvey(int userId);
    }
}
