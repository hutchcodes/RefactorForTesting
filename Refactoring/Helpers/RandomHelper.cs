using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Helpers
{
    class RandomHelper : IRandomHelper
    {
        Random _rand;

        public RandomHelper()
        {
            _rand = new Random();
        }
        public RandomHelper(int seed)
        {
            _rand = new Random(seed);
        }

        public int Next()
        {
            return _rand.Next();
        }
        public int Next(int max)
        {
            return _rand.Next(max);
        }
        public int Next(int min, int max)
        {
            return _rand.Next(min, max);
        }
    }
}
