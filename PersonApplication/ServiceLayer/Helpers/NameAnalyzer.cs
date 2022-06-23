using System.Text.RegularExpressions;

namespace ServiceLayer.ServiceHelpers
{
    internal static class NameAnalyzer
    {
        private static readonly string vowelsRegex = @"[aeiou]";
        private static readonly string consonantsRegex = @"[a-z-[aeiou]]";

        public static int GetNumberOfVowels(string name)
        {
            return new Regex(vowelsRegex, RegexOptions.IgnoreCase).Matches(name).Count;
        }
        public static int GetNumberOfConsonants(string name)
        {
            return new Regex(consonantsRegex, RegexOptions.IgnoreCase).Matches(name).Count;
        }

        public static string GetReversedName(string name)
        {
            char[] stringArray = name.ToCharArray();
            Array.Reverse(stringArray);
            return new string(stringArray);
        }
    }
}
