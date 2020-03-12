namespace Trainings.Controller.Tests.Tests
{
    using System.Collections.Generic;
    using Trainings.Common.Helpers;
    using Trainings.Controller.Tests.Helpers;
    using Xunit;

    public class HelpersTests
    {
        [Fact(DisplayName = "NoneStringIsNullOrWhitespace_NullList_ShouldReturnFalse")]
        public void NoneStringIsNullOrWhitespace01()
        {
            IEnumerable<string> stringsToValidate = null;
            bool? result = CommonHelpers.NoneStringIsNullOrWhitespace(stringsToValidate);
            Assert.False(result);
        }

        [Fact(DisplayName = "NoneStringIsNullOrWhitespace_EmptyList_ShouldReturnTrue")]
        public void NoneStringIsNullOrWhitespace02()
        {
            IEnumerable<string> stringsToValidate = new List<string>();
            bool? result = CommonHelpers.NoneStringIsNullOrWhitespace(stringsToValidate);
            Assert.True(result);
        }

        [Theory(DisplayName = "NoneStringIsNullOrWhitespace_FilledList_ShouldReturnValue")]
        [InlineData("first", "second", "third", true)]
        [InlineData("", "second", "third", false)]
        [InlineData("first", "  ", "third", false)]
        [InlineData("first", null, "third", false)]
        public void NoneStringIsNullOrWhitespace03(string first, string second, string third, bool expectedResult)
        {
            IEnumerable<string> stringsToValidate = CommonHelpersHelpers.BuildThreeElementsStringList(first, second, third);
            bool? actualResult = CommonHelpers.NoneStringIsNullOrWhitespace(stringsToValidate);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
