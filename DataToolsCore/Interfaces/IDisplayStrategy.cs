//

namespace DataToolsCore.Interfaces
{
    using System.Collections.Generic;

    public interface IDisplayStrategy
    {
        double GetDisplayValue(IList<double> values);
    }
}