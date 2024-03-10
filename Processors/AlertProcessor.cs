using FeelingOldYet.Models;

namespace Processors
{
    public class AlertProcessor
    {
        private static readonly Dictionary<AgeRange, AgeCategories> AlertTable = new Dictionary<AgeRange, AgeCategories>()
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
            {AgeCategories.Baby, "Wow, just a little baby! I guess you aren't too old." },
            {AgeCategories.Toddler, "As a toddler, have you passed the terrible twos yet? If so, you must be 3 going on 30." },
            {AgeCategories.Kid, "Enjoy being a kid and outside with no responsibilities for as long as possible!" },
            {AgeCategories.Teenager, "Uh oh, look out for the angsty teen phase." },
            {AgeCategories.Young_Adult, "The world is your oyster, young adult. Enjoy it before the back pains kick in." },
            {AgeCategories.Adult, "Some how you have both all the power and no power as an adult." },
            {AgeCategories.Retired_Adult, "You've worked long enough old champ, enjoy retirement." },
            {AgeCategories.Error, "An invalid age was entered, if you're younger than 0 and older than 100, I do not support your age!" }
        };
        
        public AlertProcessor() { }

        public static AgeCategories FindAppropriateAlert(int age)
        {
            var ageCategory = AlertTable.Where(x => x.Key.Minimum <= age && age <= x.Key.Maximum);
            var chosenAlert = AgeCategories.Unknown;
            foreach (var item in ageCategory)
            {
                chosenAlert = item.Value;
            }
            return chosenAlert;
        }

        public static bool ValidateAge(int ageInYears)
        {
            return ageInYears >= 0 && ageInYears <= 100;
        }

        public static void ProcessPerson(Person person)
        {
            if (ValidateAge(person.AgeInYears))
            {
                var ageCategory = FindAppropriateAlert(person.AgeInYears);
                person.AlertMessage = DisplayMessages[ageCategory];
            }
            else
            {
                person.AlertMessage = DisplayMessages[AgeCategories.Error];
            }
        }
    }
}