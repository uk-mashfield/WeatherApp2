//

using System.Diagnostics.CodeAnalysis;
using BaseUnitTests;
using NUnit.Framework;
using BaseUnitTests.Generic;

namespace DataTools.UnitTests.DisplayStrategy
{
    using DataTools.DisplayStrategy;
    using DataToolsCore.Interfaces;

    [ExcludeFromCodeCoverage]
    public abstract class Given_A_IDisplayStrategy : BaseUnitTestContext<IDisplayStrategy>
    {
        protected override void SetContext()
        {
            SUT = new AverageDisplayValue();
        }
    }
}