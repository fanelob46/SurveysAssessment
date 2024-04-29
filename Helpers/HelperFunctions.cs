using SurveysAssessment.Models;

namespace SurveysAssessment.Helpers
{
    public class HelperFunctions
    {
        public static int GetUserAge(User user)
        {
            if(user == null)
                return 0;

            var age = DateTime.Now.Year - user.DateOfBirth.Year;

            return age;
        }

        public static double GetPercentageOfLikePizza(List<UserFavouriteFoods> allFavouriteFoods)
        {
            var likePizza = (double)allFavouriteFoods.Where(f => f.Pizza == true).Count();

            var percent = (likePizza / allFavouriteFoods.Count) * 100;

            return percent;
        }

        public static double GetPercentageOfLikePasta(List<UserFavouriteFoods> allFavouriteFoods)
        {
            var likePasta = (double)allFavouriteFoods.Where(f => f.Pasta == true).Count();

            var percent = (likePasta / allFavouriteFoods.Count) * 100;

            return percent;
        }

        public static double GetPercentageOfLikePapAndWors(List<UserFavouriteFoods> allFavouriteFoods)
        {
            var likePapAndWors = (double)allFavouriteFoods.Where(f => f.PapAndWors == true).Count();

            var percent = (likePapAndWors / allFavouriteFoods.Count) * 100;

            return percent;
        }

        public static double GetAverageOfWatchMovies(List<UserActivityRatings> allRatings)
        {
            var watchMovies = (double)allRatings.Sum(r => r.WatchMovies);

            var average = (watchMovies / allRatings.Count);

            return average;
        }

        public static double GetAverageOfListenRadio(List<UserActivityRatings> allRatings)
        {
            var listenRatio = (double)allRatings.Sum(r => r.ListenRadio);

            var average = (listenRatio / allRatings.Count);

            return average;
        }

        public static double GetAverageOfEatOut(List<UserActivityRatings> allRatings)
        {
            var eatOut = (double)(double)allRatings.Sum(r => r.EatOut);

            var average = (eatOut / allRatings.Count);

            return average;
        }

        public static double GetAverageOfWatchTV(List<UserActivityRatings> allRatings)
        {
            var watchTV = (double) allRatings.Sum(r => r.WatchMovies);

            var average = (watchTV / allRatings.Count);

            return average;
        }
    }
}
