namespace Trainings.Common.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    public static class CommonHelpers
    {
        #region IsNull
        public static bool IsNull(
            this object objectValue)
        {
            return objectValue == null;
        }
        #endregion

        #region IsNullOrWhiteSpace

        public static bool IsNullOrWhiteSpace(
            this string stringValue)
        {
            return string.IsNullOrWhiteSpace(stringValue);
        }

        #endregion

        #region IsNullOrEmpty
        public static bool IsNullOrEmpty(
           this IEnumerable<object> objectList)
        {
            return objectList == null || !objectList.Any();
        }
        #endregion

        #region NoneStringIsNullOrWhitespace
       
        public static bool HasAtLeastOneNullOrWhitespace(this IEnumerable<string> stringsToValidate)
        {
            if (stringsToValidate.IsNull())
            {
                return true;
            }

            foreach (string stringToValidate in stringsToValidate)
            {
                if (stringToValidate.IsNullOrWhiteSpace()) 
                    return true;
            }
            return false;
        }

        #endregion
    }
}
