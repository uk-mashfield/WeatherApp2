//

using System.Diagnostics.CodeAnalysis;
using BaseUnitTests;
using NUnit.Framework;
using BaseUnitTests.Generic;

namespace DataTools.UnitTests.DataConverterTests
{
    using Converters;
    using DataToolsCore.Interfaces;

    [ExcludeFromCodeCoverage]
    public abstract class Given_A_DataConverter : BaseUnitTestContext<IDataConverters>
    {
        protected override void SetContext()
        {
            SUT = new DataConverters();
        }
    }
}