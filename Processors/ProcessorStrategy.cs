using FeelingOldYet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors
{
    public class ProcessorStrategy : IProcessorStrategy
    {
        #region Properties
        private readonly IEnumerable<IProcessor> Processors;
        #endregion

        #region Constructors
        public ProcessorStrategy(IEnumerable<IProcessor> processors)
        {
            Processors = processors;
        }
        #endregion

        #region Methods
        public void ProcessPerson(Person person) 
        {
            foreach (IProcessor processor in Processors)
            {
                processor.ProcessPerson(person);
            }
        }
        #endregion
    }
}
