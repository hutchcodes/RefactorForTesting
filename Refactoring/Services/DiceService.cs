using Refactoring.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Services
{
    class DiceService
    {
        IRandomHelper _random;
        public DiceService(IRandomHelper random = null)
        {
            _random = random ?? new RandomHelper();
        }
        public int Roll(int numberOfDice, int numberOfSides)
        {
            var total = 0;

            for (int i = 0; i < numberOfDice; i++)
            {
                total += _random.Next(1, numberOfSides);
            }

            return total;
        }
    }
}
