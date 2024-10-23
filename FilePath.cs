using System;
using System.IO;

namespace WordCounterApp.Services
{
    public class FilePath
    {
        public void ProcessFiles()
        {
            Console.WriteLine("Введите путь до созданного файла:");
            string inputPath = Console.ReadLine();

            Console.WriteLine("Введите путь до создаваемого файла:");
            string outputPath = Console.ReadLine();

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Файл не найден\nRestart");
                    return;
                }
                FileReader reader = new FileReader();
                reader.ReadAndProcess(inputPath, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файлов: {ex.Message}");
            }
        
        Console.WriteLine("Файл успешно обработан.");
        }
    }
}
