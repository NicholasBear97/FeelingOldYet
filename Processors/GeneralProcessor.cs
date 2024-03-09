using FeelingOldYet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeProcessors
{
    public class GeneralProcessor : IProcessor
    {
        private IProcessor AlertProcessor;
        private IProcessor DaysProcessor;
        private IProcessor LeaderboardProcessor;


        public GeneralProcessor()
        {
            AlertProcessor = new AlertProcessor();
            DaysProcessor = new DaysProcessor();
            LeaderboardProcessor = new LeaderBoardProcessor();
        }
        public void Process(Person person)
        {
            SavePersonToDB(person);
            PerformAgeLogic(person);
        }

        public void SavePersonToDB(Person person) { }
        public void PerformAgeLogic(Person person)
        {
            SendToDaysProcessor(person);
            SendToAlertProcessor(person);
            SendToLeaderBoardProcessor(person);
        }

        public void SendToDaysProcessor(Person person)
        {
            AlertProcessor.Process(person);
        }
        public void SendToAlertProcessor(Person person) 
        { 
            DaysProcessor.Process(person); 
        }
        public void SendToLeaderBoardProcessor(Person person) 
        {
            LeaderboardProcessor.Process(person);
        }
    }
}
