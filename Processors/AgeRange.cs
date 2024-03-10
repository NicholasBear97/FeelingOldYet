using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors
{
    public class AgeRange
    {
        #region Properties
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        #endregion

        #region Constructors
        AgeRange() { }

        public AgeRange(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
        #endregion
    }
}
