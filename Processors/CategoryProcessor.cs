using FeelingOldYet.Models;

namespace Processors
{
    public class CategoryProcessor : IProcessor
    {
        #region Constants
        private static readonly Dictionary<AgeRange, AgeCategories> AgeCategoryTable = new Dictionary<AgeRange, AgeCategories>()
        {
            {new AgeRange(0,0), AgeCategories.Baby },
            {new AgeRange(1,4), AgeCategories.Toddler },
            {new AgeRange(5,12), AgeCategories.Kid },
            {new AgeRange(13,17), AgeCategories.Teenager },
            {new AgeRange(18,29), AgeCategories.Young_Adult },
            {new AgeRange(30,64), AgeCategories.Adult },
            {new AgeRange(65,100), AgeCategories.Retired_Adult }
        };

        private static readonly Dictionary<AgeCategories, string> DisplayMessages = new Dictionary<AgeCategories, string>()
        {
            {AgeCategories.Baby, "Baby" },
            {AgeCategories.Toddler, "Toddler" },
            {AgeCategories.Kid, "Kid" },
            {AgeCategories.Teenager, "Teen" },
            {AgeCategories.Young_Adult, "Young Adult" },
            {AgeCategories.Adult, "Adult" },
            {AgeCategories.Retired_Adult, "Retired Adult" },
            {AgeCategories.Invalid_Age, "Invalid Age" }
        };
        #endregion

        #region Constructors
        public CategoryProcessor() { }
        #endregion

        #region Methods
        /// <summary>
        /// Finds the category for a person based on their age in  years.
        /// </summary>
        /// <param name="age"></param>
        /// <returns>Age Category in enum value.</returns>
        public static AgeCategories FindAppropriateCategory(int age)
        {
            var ageCategory = AgeCategoryTable.Where(x => x.Key.Minimum <= age && age <= x.Key.Maximum);
            var chosenAlert = AgeCategories.Unknown;
            foreach (var item in ageCategory)
            {
                chosenAlert = item.Value;
            }
            return chosenAlert;
        }

        /// <summary>
        /// Validates that the age in years is supported. If it is not then the error category will be assigned.
        /// </summary>
        /// <param name="ageInYears"></param>
        /// <returns>True/False if age <= 100 and age >= 0.</returns>
        public static bool ValidateAge(int ageInYears)
        {
            return ageInYears >= 0 && ageInYears <= 100;
        }

        /// <summary>
        /// Adds the correct age category for a person based on their age in years.
        /// </summary>
        /// <param name="person">Accepts any Person object.</param>
        public void ProcessPerson(Person person)
        {
            if (ValidateAge(person.AgeInYears))
            {
                var ageCategory = FindAppropriateCategory(person.AgeInYears);
                person.AgeCategory = DisplayMessages[ageCategory];
            }
            else
            {
                person.AgeCategory = DisplayMessages[AgeCategories.Invalid_Age];
            }
        }
        #endregion
    }
}