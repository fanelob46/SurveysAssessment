
namespace SurveysAssessment.ViewModels
{
    public class NewSurveyViewModel
    {
        public int UserId { get; set; }

        public int SurveyId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ContactNumber { get; set; }

        public bool Pizza { get; set; }

        public bool Pasta { get; set; }

        public bool PapAndWors { get; set; }

        public bool Other { get; set; }

        public int WatchMovies { get; set; }

        public int ListenRadio { get; set; }

        public int EatOut { get; set; }

        public int WatchTV { get; set; }
    }
}

