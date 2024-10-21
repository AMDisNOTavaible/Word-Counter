using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace UniqueWordCounterApp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до созданного файла и для создания файла.");

            string inputFilePath = Convert.ToString(Console.ReadLine());  // Путь к первому файлу (существующему)

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Файл не найден\nRestart");
                return;
            }

            string outputFilePath = Convert.ToString(Console.ReadLine()); // Путь ко второму файлу (будет создан)

            // Вызов классов для выполнения задач
            FileReader reader = new FileReader(inputFilePath);
            var words = reader.ReadWords();

            WordProcessor processor = new WordProcessor(words);
            var uniqueWords = processor.GetUniqueWords();
            var repeatedWords = processor.GetRepeatedWords();
            int totalWords = processor.GetTotalWordCount();

            FileWriter writer = new FileWriter(outputFilePath);
            writer.WriteResults(uniqueWords, repeatedWords, totalWords);
        }
    }

    // Класс для чтения файла
    class FileReader
    {
        private string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        // Метод для чтения всех слов из файла
        public List<string> ReadWords()
        {
            try
            {
                string text = File.ReadAllText(_filePath);
                // Разделение текста на слова с использованием разделителей
                var words = text.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                return words.Select(word => word.ToLower()).ToList(); // Приведение к нижнему регистру
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
                return new List<string>();
            }
        }
    }

    // Класс для обработки текста (подсчет уникальных и повторяющихся слов)
    class WordProcessor
    {
        private List<string> _words;

        public WordProcessor(List<string> words)
        {
            _words = words;
        }

        // Получение списка уникальных слов (которые встречаются один раз)
        public List<string> GetUniqueWords()
        {
            var wordCount = _words.GroupBy(w => w)
                                  .Where(g => g.Count() == 1)
                                  .Select(g => g.Key)
                                  .ToList();
            return wordCount;
        }

        // Получение списка повторяющихся слов и их количества
        public Dictionary<string, int> GetRepeatedWords()
        {
            var repeatedWords = _words.GroupBy(w => w)
                                      .Where(g => g.Count() > 1)
                                      .ToDictionary(g => g.Key, g => g.Count());
            return repeatedWords;
        }

        // Получение общего количества слов
        public int GetTotalWordCount()
        {
            return _words.Count;
        }
    }

    // Класс для записи результатов в файл
    class FileWriter
    {
        private string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        // Запись результатов в файл
        public void WriteResults(List<string> uniqueWords, Dictionary<string, int> repeatedWords, int totalWordCount)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    writer.WriteLine($"Количество всех слов - {totalWordCount}");
                    writer.WriteLine($"Уникальных слов - {uniqueWords.Count}");
                    writer.WriteLine("Уникальные слова:");
                    foreach (var word in uniqueWords)
                    {
                        writer.WriteLine(word);
                    }

                    writer.WriteLine("\nПовторяющиеся слова:");
                    foreach (var word in repeatedWords)
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
