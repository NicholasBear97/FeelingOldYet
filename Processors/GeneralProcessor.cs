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

        public void Process(int age)
        {
            SendToDaysProcessor(age);
            SendToAlertProcessor(age);
            SendToLeaderBoardProcessor(age);
        }

        public void SendToDaysProcessor(int age)
        {
            AlertProcessor.Process(age);
        }
        public void SendToAlertProcessor(int age) 
        { 
            DaysProcessor.Process(age); 
        }
        public void SendToLeaderBoardProcessor(int age) 
        {
            LeaderboardProcessor.Process(age);
        }
    }
}
