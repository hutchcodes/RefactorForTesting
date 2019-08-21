using NUnit.Framework;
using Refactoring.Helpers;
using Refactoring.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;

namespace Refactoring.Tests.Services
{
    class DiceServiceTests
    {
        [TestCase(2, 6, 12)]
        [TestCase(3, 6, 18)]
        [TestCase(2, 20, 40)]
        public void Should_roll_dice_multiple_times(int times, int sides, int expected)
        {
            var random = Mock.Create<IRandomHelper>();
            Mock.Arrange(() => random.Next()).Occurs(times);

            var roller = new DiceService(random);

            var totalRoll = roller.Roll(times, sides);

            Assert.AreEqual(expected, totalRoll);
        }
    }
}
