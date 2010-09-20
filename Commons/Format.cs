using System.Globalization;

namespace Commons
{
    public static class Format
    {
        public const string CultureName = "en-US";
        public const string GradeFormat = "0.00";

        private static readonly CultureInfo Culture = new CultureInfo(CultureName, false);

        public static string Grade(decimal gradeValue)
        {
            return gradeValue.ToString(GradeFormat, Culture);
        }
    }
}
