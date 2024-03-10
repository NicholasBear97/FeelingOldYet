using System.ComponentModel.DataAnnotations.Schema;

namespace FeelingOldYet.Models
{
    public class Person
    {
        #region Properties
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

                if (value >= 0 && value <= 100)
                {
                    AgeInDays = ConvertYearsToDays(value);
                }
            }
        }

        public string? AgeCategory { get; set; } = string.Empty;
        public int AgeInDays { get; set; } = 0;

        public string? FunFact { get; set; } = string.Empty;

        #endregion

        #region Constructors
        public Person() { }

        public Person(int ageInYears)
        {
            AgeInYears = ageInYears;

            AgeInDays = ConvertYearsToDays(ageInYears);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Convert input number of years to number of days.
        /// </summary>
        /// <param name="ageInYears"></param>
        /// <returns>Returns number of days for a corresponding input of years.</returns>
        public int ConvertYearsToDays(int ageInYears)
        {
            int baseAgeInDays = ageInYears * 365;
            decimal leapDays = ageInYears / 4;
            var rawAgeInDays = baseAgeInDays + leapDays;
            bool conversionSuccess = int.TryParse(rawAgeInDays.ToString(), out int ageInDays);
            return conversionSuccess ? ageInDays : baseAgeInDays;
        }
        #endregion
    }
}
