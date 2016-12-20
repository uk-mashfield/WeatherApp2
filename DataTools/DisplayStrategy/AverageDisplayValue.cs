//
namespace DataTools.DisplayStrategy
{
    using System.Collections.Generic;
    using System.Linq;
    using DataToolsCore.Interfaces;

    public class AverageDisplayValue : IDisplayStrategy
    {
        public double GetDisplayValue(IList<double> values)
        {
            // dont div by zero
            if (values.Count > 0)
            {
                return values.Sum() / values.Count;
            }

            return 0d;
        }
    }
}