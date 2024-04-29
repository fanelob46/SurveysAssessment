using System.ComponentModel.DataAnnotations;

namespace SurveysAssessment.Models
{
    public class UserActivityRatings
    {
        [Key]
        public int RatingId { get; set; }

        public int UserId { get; set; }

        public int SurveyId { get; set; }

        public int WatchMovies { get; set; }

        public int ListenRadio { get; set; }

        public int EatOut { get; set; }

        public int WatchTV { get; set; }
    }
}
