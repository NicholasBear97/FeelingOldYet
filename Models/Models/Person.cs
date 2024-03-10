using System.ComponentModel.DataAnnotations.Schema;

namespace FeelingOldYet.Models
{
    public class Person
    {
        public int Id { get; set; } = 0;

        private int ageInYears = 0;
        public int AgeInYears
        {
            get
            {
                return ageInYears;
            }
            set
            {
                ageInYears = value;
                AgeInDays = ConvertYearsToDays(value);
            }
        }

        public string? AlertMessage { get; set; } = string.Empty;
        public int AgeInDays { get; set; } = 0;


        public Person() { }

        public Person(int ageInYears)
        {
            AgeInYears = ageInYears;

            AgeInDays = ConvertYearsToDays(ageInYears);
        }

        public int ConvertYearsToDays(int ageInYears)
        {
            int baseAgeInDays = ageInYears * 365;
            decimal leapDays = ageInYears / 4;
            var rawAgeInDays = baseAgeInDays + leapDays;
            bool conversionSuccess = int.TryParse(rawAgeInDays.ToString(), out int ageInDays);
            return conversionSuccess ? ageInDays : baseAgeInDays;
        }
    }
}
