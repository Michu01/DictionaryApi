using System.Text.RegularExpressions;

namespace DictionaryApi.Services
{
    public interface IDictionaryService
    {
        IEnumerable<string> GetWords(Regex regex);

        IEnumerable<string> GetWords(IEnumerable<Regex> regexes);

        IEnumerable<string> GetWords();

        IEnumerable<string> GetWords(uint length);

        bool GetWordExists(string word);

        string GetRandomWord();

        string? GetRandomWord(uint length);
    }
}
