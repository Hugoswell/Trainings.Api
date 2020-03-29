using System.Collections.Generic;

namespace Trainings.Controller.Tests.Helpers
{
    internal static class HelpersTestsHelper
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
