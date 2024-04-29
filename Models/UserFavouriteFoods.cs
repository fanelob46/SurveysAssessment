
using System.ComponentModel.DataAnnotations;

namespace SurveysAssessment.Models
{
    public class UserFavouriteFoods
    {
        [Key]
        public int FavouriteFoodId { get; set; }

        public int UserId { get; set; }

        public int SurveyId { get; set; }

        public bool Pizza { get; set; }

        public bool Pasta { get; set; }

        public bool PapAndWors { get; set; }

        public bool Other { get; set; }
    }
}
