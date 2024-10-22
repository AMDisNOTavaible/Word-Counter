using System;
using WordCounterApp.Services;

namespace WordCounterApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите путь до созданного файла и для создания файла.");
                string inputPath = Console.ReadLine();
                string outputPath = Console.ReadLine();

                FilePath filePath = new FilePath();
                filePath.ProcessFiles(inputPath, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
