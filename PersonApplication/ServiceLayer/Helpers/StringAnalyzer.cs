﻿using System.Text.RegularExpressions;

namespace ServiceLayer.ServiceHelpers
{
    public static class StringAnalyzer
    {
        private static readonly string vowelsRegex = @"[aeiou]";
        private static readonly string consonantsRegex = @"[a-z-[aeiou]]";

        public static int GetNumberOfVowels(string name)
        {
            if (name == null)
            {
                return 0;
            }
            return new Regex(vowelsRegex, RegexOptions.IgnoreCase).Matches(name).Count;
        }
        public static int GetNumberOfConsonants(string name)
        {
            if (name == null)
            {
                return 0;
            }
            return new Regex(consonantsRegex, RegexOptions.IgnoreCase).Matches(name).Count;
        }

        public static string GetReversedName(string name)
        {
            if (name == null)
            {
                return "";
            }
            char[] stringArray = name.ToCharArray();
            Array.Reverse(stringArray);
            return new string(stringArray);
        }
    }
}