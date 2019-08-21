using NUnit.Framework;
using Refactoring.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Tests.Services
{
    class DiceServiceTests
    {
        [Test]
        public void Should_roll_dice_multiple_times()
        {
            var roller = new DiceService();

            var totalRoll = roller.Roll(2, 6);

            Assert.GreaterOrEqual(totalRoll, 2);
            Assert.LessOrEqual(totalRoll, 12);
        }
    }
}
