using DictionaryApi.Services;

using Xunit;

namespace DictionaryApiTests
{
    public class IDictionaryServiceTests
    {
        private readonly IDictionaryService _dictionaryService = new DictionaryService();

        [Theory]
        [InlineData("moveable", true)]
        [InlineData("brii", false)]
        public void GetWordExists(string word, bool expected)
        {
            bool result = _dictionaryService.GetWordExists(word);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0)]
        public void GetRandomWordShouldEqualNull(uint length)
        {
            string? result = _dictionaryService.GetRandomWord(length);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(4)]
        public void GetRandomWordShouldNotEqualNull(uint length)
        {
            string? result = _dictionaryService.GetRandomWord(length);

            Assert.NotNull(result);
        }

        [Fact]
        public void GetRandomWordShouldNotEqualNull2()
        {
            string? result = _dictionaryService.GetRandomWord();

            Assert.NotNull(result);
        }
    }
}
