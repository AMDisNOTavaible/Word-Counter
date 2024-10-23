using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordCounterApp.Services
{
    public class FileWriter
    {
        // Список запрещенных символов
        private readonly char[] invalidChars = { '#', '<', '>', '$', '+', '%', '!', '`', '/', '?', '&',
                                               '*', '\'', '"', '|', '{', '}', ':', ';', '\\', ',', '@' };

        public void ProcessAndWrite(string outputPath, List<string> words)
        {
            // Проверяем имя файла на наличие запрещенных символов
            if (ContainsInvalidCharacters(outputPath))
            {
                Console.WriteLine("Ошибка: Имя файла содержит запрещенные символы");
                Console.WriteLine($"Запрещенные символы: {string.Join(" ", invalidChars)}");
                return;
            }

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

        // Метод для проверки наличия запрещенных символов в пути файла
        private bool ContainsInvalidCharacters(string path)
        {
            // Получаем только имя файла из полного пути
            string fileName = Path.GetFileName(path);

            // Проверяем наличие запрещенных символов
            return fileName.Any(c => invalidChars.Contains(c));
        }
    }
}
