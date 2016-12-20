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
    public class When_A_Fahrenheit_Value_Is_Converted : Given_A_DataConverter
    {
        private static IDictionary<double, double> _values = new Dictionary<double, double>
        {
            {5, -15},
            {68, 20},
            {95,  35}
        };

        [TestCaseSource("_values")]
        public void Then_Values_Should_Be_Correctly_Converted(KeyValuePair<double, double> value)
        {
            Assert.AreEqual(value.Value, SUT.FahrenHeightToCelcius(value.Key));
        }
    }
}