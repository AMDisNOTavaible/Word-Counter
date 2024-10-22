using System;
using System.IO;
using System.Collections.Generic;

namespace UniqueWordCounterApp.Services
{
    public class FileWriter
    {
        public void ProcessAndWrite(string outputPath, List<string> words)
        {
            FileProcessor processor = new FileProcessor();
            var results = processor.ProcessWords(words);

            try
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine($"Количество всех слов - {results.TotalCount}");
                    writer.WriteLine($"Количество уникальных слов - {results.UniqueWords.Count}");
                    writer.WriteLine("Уникальные слова:");
                    foreach (var word in results.UniqueWords)
                    {
                        writer.WriteLine(word);
                    }

                    writer.WriteLine("\nПовторяющиеся слова:");
                    foreach (var word in results.RepeatedWords)
                    {
                        writer.WriteLine($"{word.Key} - {word.Value} ");
                    }
                }
                Console.WriteLine("Успешная запись файла.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи файла: {ex.Message}");
            }
        }
    }
}
