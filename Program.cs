using System;
using UniqueWordCounterApp.Services;

namespace UniqueWordCounterApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до созданного файла и для создания файла.");
            string inputPath = Console.ReadLine();
            string outputPath = Console.ReadLine();

            FilePath filePath = new FilePath();
            filePath.ProcessFiles(inputPath, outputPath);
        }
    }
}
