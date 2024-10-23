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
                FilePath filePath = new FilePath();
                filePath.ProcessFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
