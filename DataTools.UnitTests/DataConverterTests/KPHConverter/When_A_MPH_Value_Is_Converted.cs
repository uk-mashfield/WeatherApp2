//

using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace DataTools.UnitTests.DataConverterTests.CelcuisConverter
{
    using System.Collections.Generic;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category("DataConversionTests")]
    public class When_A_MPH_Value_Is_Converted : Given_A_DataConverter
    {
        private static IDictionary<double, double> _values = new Dictionary<double, double>
        {
            {18, 28.9682},
            {5, 8.04672},
            {93,  149.669}
        };

        [TestCaseSource("_values")]
        public void Then_Values_Should_Be_Correctly_Converted(KeyValuePair<double, double> value)
        {
            Assert.AreEqual(value.Value, SUT.MPHtoKPH(value.Key), 0.0001d);
        }
    }
}