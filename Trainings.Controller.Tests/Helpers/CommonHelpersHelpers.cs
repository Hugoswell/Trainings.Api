using System.Collections.Generic;

namespace Trainings.Controller.Tests.Helpers
{
    internal static class CommonHelpersHelpers
    {
        internal static IEnumerable<string> BuildThreeElementsStringList(string first, string second, string third)
        {
            return new List<string>
            {
                first,
                second,
                third
            };
        }
    }
}
