using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Впишите путь до созданного файла");
        string firstFilePath = Convert.ToString(Console.ReadLine()); // Путь до созданного файла

        if (File.Exists(firstFilePath))
        {
            Console.WriteLine("Файл найден");
        }
        else
        {
            Console.WriteLine("Файл не найден\nПерезапустите программу и вставьте верный путь до файла");
 
            return;
        }

        Console.WriteLine("Впишите путь до создаваемого файла");
        string secondFilePath = Convert.ToString(Console.ReadLine()); // Путь до создаваеммого файла

        // Читает первый файл
        var wordCounts = ReadWordsAndCount(firstFilePath);

        // Пишет количество слов во второй файл
        WriteResultsToFile(secondFilePath, wordCounts);
    }

    // Функция для чтения слов из файла и подсчета их повтора
    static Dictionary<string, int> ReadWordsAndCount(string filePath)
    {
        var wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        // Читает все строки в файле
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            // Разабивает каждую строку на слова (при условии, что слова разделены пробелами или знаками препинания).
            var words = line.Split(new[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                // Считает количество слов
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }
        }

        return wordCounts;
    }

    // Функция для записи количества слов и уникальных слов в создаваеммый файл
    static void WriteResultsToFile(string filePath, Dictionary<string, int> wordCounts)
    {
        using (var writer = new StreamWriter(filePath))
        {
            // Подсчитывает уникальные слова
            var uniqueWords = wordCounts.Where(kvp => kvp.Value == 1).ToList();
            writer.WriteLine($"Количество уникальных слов: {uniqueWords.Count}");

            // Пишет список уникальных слов
            writer.WriteLine("Уникальные слова:");
            foreach (var kvp in uniqueWords)
            {
                writer.WriteLine(kvp.Key);
            }

            // Записывает количество каждого слова, которое встречается более одного раза
            writer.WriteLine("\nСколько раз встретилось слово/символ:");
            foreach (var kvp in wordCounts.Where(kvp => kvp.Value > 1))
            {
                writer.WriteLine($"{kvp.Key} = {kvp.Value}");
            }
        }
    }
}
