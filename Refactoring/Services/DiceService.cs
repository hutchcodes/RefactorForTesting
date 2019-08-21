using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Services
{
    class DiceService
    {
        public int Roll(int numberOfDice, int numberOfSides)
        {
            var total = 0;

            var rand = new Random();

            for (int i = 0; i < numberOfDice; i++)
            {
                total += rand.Next(1, numberOfSides);
            }

            return total;
        }
    }
}
