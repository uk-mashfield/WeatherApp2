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
    public class When_A_KPH_Value_Is_Converted : Given_A_DataConverter
    {
        private static IDictionary<double, double> _values = new Dictionary<double, double>
        {
            {18, 11.1847},
            {37, 22.9907},
            {93,  57.7875}
        };

        [TestCaseSource("_values")]
        public void Then_Values_Should_Be_Correctly_Converted(KeyValuePair<double, double> value)
        {
            Assert.AreEqual(value.Value, SUT.KPHtoMPH(value.Key), 0.0001d);
        }
    }
}