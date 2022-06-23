using System.Text.RegularExpressions;

namespace ServiceLayer.ServiceHelpers
{
    /// <summary>
    /// StringAnalyzer class used for analyzing string content.
    /// </summary>
    public static class StringAnalyzer
    {
        private static readonly string vowelsRegex = @"[aeiou]";
        private static readonly string consonantsRegex = @"[a-z-[aeiou]]";

        /// <summary>
        /// Gets number of vowels in the string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns></returns>
        public static int GetNumberOfVowels(string input)
        {
            if (input == null)
            {
                return 0;
            }
            return new Regex(vowelsRegex, RegexOptions.IgnoreCase).Matches(input).Count;
        }

        /// <summary>
        /// Gets number of consonants in the string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns></returns>
        public static int GetNumberOfConsonants(string input)
        {
            if (input == null)
            {
                return 0;
            }
            return new Regex(consonantsRegex, RegexOptions.IgnoreCase).Matches(input).Count;
        }

        /// <summary>
        /// Gets reversed string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns></returns>
        public static string GetReversedString(string input)
        {
            if (input == null)
            {
                return "";
            }
            char[] stringArray = input.ToCharArray();
            Array.Reverse(stringArray);
            return new string(stringArray);
        }
    }
}
