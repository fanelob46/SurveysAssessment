﻿
namespace SurveysAssessment.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ContactNumber { get; set; }
    }
}
