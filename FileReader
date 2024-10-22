using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace UniqueWordCounterApp.Services
{
    public class FileReader
    {
        public void ReadAndProcess(string inputPath, string outputPath)
        {
            try
            {
                string text = File.ReadAllText(inputPath);
                var words = text.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.ToLower()).ToList();
                FileWriter writer = new FileWriter();
                writer.ProcessAndWrite(outputPath, words);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }
        }
    }
}
