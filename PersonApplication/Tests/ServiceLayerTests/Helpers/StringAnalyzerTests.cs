using Xunit;
using ServiceLayer.ServiceHelpers;

namespace ServiceLayerTests
{
    /// <summary>
    /// StringAnalyzer unit tests class.
    /// </summary>
    public class StringAnalyzerTests
    {
        /// <summary>
        /// Tests counting number of vowels.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="expectedCount">Expected result.</param>
        [Theory]
        [InlineData("Jane Doe", 4)]
        [InlineData("Name MiddleName Surname", 9)]
        [InlineData("!!!spec ch@rs in n@me", 3)]
        [InlineData("123455", 0)]
        [InlineData(null, 0)]
        [InlineData("    ", 0)]
        [InlineData("", 0)]
        public void GetNumberOfVowelsTest(string input, int expectedCount)
        {
            int count = StringAnalyzer.GetNumberOfVowels(input);
            Assert.Equal(expectedCount, count);
        }

        /// <summary>
        /// Tests counting number of consonants.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="expectedCount">Expected result.</param>
        [Theory]
        [InlineData("Jane Doe", 3)]
        [InlineData("Name MiddleName Surname", 12)]
        [InlineData("!!!spec ch@rs in n@me", 10)]
        [InlineData("123455", 0)]
        [InlineData(null, 0)]
        [InlineData("    ", 0)]
        [InlineData("", 0)]
        public void GetNumberOfConsonantsTest(string input, int expectedCount)
        {
            int count = StringAnalyzer.GetNumberOfConsonants(input);
            Assert.Equal(expectedCount, count);
        }

        /// <summary>
        /// Tests string reversing.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="expectedReversedString">Expected reversed string.</param>
        [Theory]
        [InlineData("Jane Doe", "eoD enaJ")]
        [InlineData("Name MiddleName Surname", "emanruS emaNelddiM emaN")]
        [InlineData("!!!spec ch@rs in n@me", "em@n ni sr@hc ceps!!!")]
        [InlineData("123455", "554321")]
        [InlineData(null, "")]
        [InlineData("    ", "    ")]
        [InlineData("", "")]
        public void GetReversedNameTest(string input, string expectedReversedString)
        {
            string reversedString = StringAnalyzer.GetReversedName(input);
            Assert.Equal(expectedReversedString, reversedString);
        }
    }
}