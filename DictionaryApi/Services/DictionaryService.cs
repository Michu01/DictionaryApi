using System.Text.RegularExpressions;

namespace DictionaryApi.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly IEnumerable<string> words;

        public DictionaryService()
        {
            words = File.ReadAllLines("words.txt");
        }

        public IEnumerable<string> GetWords(Regex regex)
        {
            return words.Where(w => regex.IsMatch(w));
        }

        public IEnumerable<string> GetWords(IEnumerable<Regex> regexes)
        {
            return words.Where(w => regexes.All(regex => regex.IsMatch(w)));
        }

        public string? GetRandomWord(uint length)
        {
            IEnumerable<string> words = GetWords(length);

            if (!words.Any()) 
            {
                return null;
            }

            Random rand = new();
            int number = rand.Next(words.Count());

            return words.ElementAt(number);
        }

        public IEnumerable<string> GetWords(uint length)
        {
            return words.Where(w => w.Length == length);
        }

        public bool GetWordExists(string word)
        {
            return words.Any(word.Equals);
        }

        public IEnumerable<string> GetWords()
        {
            return words;
        }

        public string GetRandomWord()
        {
            Random rand = new();
            int number = rand.Next(words.Count());

            return words.ElementAt(number);
        }
    }
}
