using DataService;
using FeelingOldYet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors
{
    public class FactProcessor : IProcessor
    {
        #region Properties
        public DbDataService DataService;
        public List<Person> People;
        #endregion

        #region Constructors
        public FactProcessor (DbDataService dataService) 
        {
            DataService = dataService;
            People = dataService.People.ToList();
        }
        #endregion

        #region Methods
        public void ProcessPerson(Person person)
        {
            if (People != null) 
            {
                ///<remarks>
                ///The person currently being processed will not be saved at this point.
                ///So if the count = 0, ATP, there will only be one person in the people list by the end of ALL processing.
                ///We will also need to generate the fact for that specific person separately since they won't be saved.
                /// </remarks>
                if (People.Count > 0)
                {
                    RefreshPeople(person);
                }
                else
                {
                    person.FunFact = "Please enter another age for a fun fact!";
                }
            }

        }

        /// <summary>
        /// Regenerates the fun fact property for every person in the People list, even the person currently being processed.
        /// </summary>
        /// <param name="person"></param>
        public void RefreshPeople(Person person)
        {
            List<Person> tempPeople = People;
            tempPeople.Add(person);

            //ATP we are not concerned about the specific person going through processing.
            foreach (Person personToSave in tempPeople)
            {
                personToSave.FunFact = GeneratedFact(personToSave, tempPeople);
            }
        }

        /// <summary>
        /// Generic method that focuses on any person used.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="tempPeople"></param>
        /// <returns></returns>
        public string GeneratedFact(Person person, List<Person> tempPeople)
        {
            string percentage = GeneratePercentage(person, tempPeople);
            return string.Format("You're older than {0}% of people who converted their age!", percentage);
        }

        /// <summary>
        /// Checks how many people are younger than the personToCheck.
        /// </summary>
        /// <param name="personToCheck"></param>
        /// <param name="tempPeople"></param>
        /// <returns></returns>
        public string GeneratePercentage(Person personToCheck, List<Person> tempPeople)
        {
            double olderThan = 0;
            double totalPeople = 0;

            foreach (Person person in tempPeople)
            {
                if (personToCheck.Id != person.Id) 
                {
                    if (personToCheck.AgeInYears > person.AgeInYears)
                    {
                        olderThan++;
                    }

                    //If two people have the same age then one cannot be older.
                    //Remove the total count of people and do not increment the older than variable.
                    if (personToCheck.AgeInYears == person.AgeInYears)
                    {
                        totalPeople--;
                    }

                    totalPeople++;
                }
            }

            double percenttest = Convert.ToDouble(olderThan / (totalPeople));
            double percentage = Math.Truncate(percenttest * 100);
            return percentage.ToString();
        }
        #endregion
    }
}
