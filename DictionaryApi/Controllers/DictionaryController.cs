using System.Text.RegularExpressions;

using DictionaryApi.Services;

using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly IDictionaryService _dictionaryService;

        private readonly ILogger<DictionaryController> _logger;

        public DictionaryController(ILogger<DictionaryController> logger, IDictionaryService dictionaryService)
        {
            _logger = logger;
            _dictionaryService = dictionaryService;
        }

        [HttpGet]
        [Route("Length")]
        public IEnumerable<string> GetWords(uint length)
        {
            return _dictionaryService.GetWords(length);
        }

        [HttpGet]
        [Route("Regex")]
        public IEnumerable<string> GetWords([FromQuery]IEnumerable<string> patterns)
        {
            IEnumerable<Regex> regexes = patterns.Select(pattern => new Regex(pattern));

            return _dictionaryService.GetWords(regexes);
        }

        [HttpGet]
        [Route("Exists")]
        public bool GetWordExists(string word)
        {
            return _dictionaryService.GetWordExists(word);
        }

        [HttpGet]
        [Route("Random")]
        public string? GetRandomWord(uint? length)
        {
            return length.HasValue ? _dictionaryService.GetRandomWord(length.Value) : _dictionaryService.GetRandomWord();
        }
    }
}
