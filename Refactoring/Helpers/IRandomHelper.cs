namespace Refactoring.Helpers
{
    interface IRandomHelper
    {
        int Next();
        int Next(int max);
        int Next(int min, int max);
    }
}