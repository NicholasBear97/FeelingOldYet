using FeelingOldYet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors
{
    public interface IProcessorStrategy
    {
        public void ProcessPerson(Person person);
    }
}
