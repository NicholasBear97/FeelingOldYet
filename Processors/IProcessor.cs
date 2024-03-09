using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeProcessors
{
    public interface IProcessor
    {
        public void Process(int age);
    }
}
