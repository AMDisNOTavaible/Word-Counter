using System;
using System.IO;

namespace WordCounterApp.Services
{
    public class FilePath
    {
        public void ProcessFiles(string inputPath, string outputPath)
        {
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
        }
    }
}
