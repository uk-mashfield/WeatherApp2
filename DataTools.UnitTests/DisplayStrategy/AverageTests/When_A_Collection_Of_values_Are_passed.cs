//

using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace DataTools.UnitTests.DisplayStrategy.AverageTests
{
    using System.Collections.Generic;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category("Average Tests")]
    public class When_A_Collection_Of_values_Are_passed : Given_A_IDisplayStrategy
    {
        [Test]
        public void Then_The_Average_Of_The_Values_Should_Be_Returned()
        {
            var input = new List<double>
            {
                90,
                10,
                30,
                75,
                96
            };

            var expected = 60.2d;

            Assert.AreEqual(expected, SUT.GetDisplayValue(input), 0.1d);
        }
    }
}