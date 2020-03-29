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
            bool? result = CommonHelpers.HasAtLeastOneNullOrWhitespace(stringsToValidate);
            Assert.True(result);
        }

        [Fact(DisplayName = "NoneStringIsNullOrWhitespace_EmptyList_ShouldReturnTrue")]
        public void NoneStringIsNullOrWhitespace02()
        {
            IEnumerable<string> stringsToValidate = new List<string>();
            bool? result = CommonHelpers.HasAtLeastOneNullOrWhitespace(stringsToValidate);
            Assert.False(result);
        }

        [Theory(DisplayName = "NoneStringIsNullOrWhitespace_FilledList_ShouldReturnValue")]
        [InlineData("first", "second", "third", false)]
        [InlineData("", "second", "third", true)]
        [InlineData("first", "  ", "third", true)]
        [InlineData("first", null, "third", true)]
        public void NoneStringIsNullOrWhitespace03(string first, string second, string third, bool expectedResult)
        {
            IEnumerable<string> stringsToValidate = HelpersTestsHelper.BuildThreeElementsStringList(first, second, third);
            bool? actualResult = CommonHelpers.HasAtLeastOneNullOrWhitespace(stringsToValidate);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
