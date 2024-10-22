using System.Linq;
using System.Collections.Generic;

namespace UniqueWordCounterApp.Services
{
    public class FileProcessor
    {
        public (List<string> UniqueWords, Dictionary<string, int> RepeatedWords, int TotalCount) ProcessWords(List<string> words)
        {
            var uniqueWords = words.GroupBy(w => w)
                                 .Where(g => g.Count() == 1)
                                 .Select(g => g.Key)
                                 .ToList();

            var repeatedWords = words.GroupBy(w => w)
                                   .Where(g => g.Count() > 1)
                                   .ToDictionary(g => g.Key, g => g.Count());

            return (uniqueWords, repeatedWords, words.Count);
        }
    }
}
