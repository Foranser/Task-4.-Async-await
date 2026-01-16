using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Task4.AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string folderPath = args.Length > 0
                ? args[0]
                : Environment.CurrentDirectory;

            Console.WriteLine($"Папка: {folderPath}");

            await RunScenario1(folderPath);
            await RunScenario2(folderPath);
        }

        static async Task RunScenario1(string folderPath)
        {
            Console.WriteLine();
            Console.WriteLine("Сценарий 1: Task на файл (чтение целиком)");

            var files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

            var stopwatch = Stopwatch.StartNew();

            var tasks = files.Select(file => Task.Run(async () =>
            {
                var text = await File.ReadAllTextAsync(file);
                return text.Count(c => c == ' ');
            })).ToArray();

            var results = await Task.WhenAll(tasks);

            stopwatch.Stop();

            Console.WriteLine($"Пробелов: {results.Sum()}");
            Console.WriteLine($"Время: {stopwatch.ElapsedMilliseconds} мс");
        }

        static async Task RunScenario2(string folderPath)
        {
            Console.WriteLine();
            Console.WriteLine("Сценарий 2: Task на строку");

            var files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

            var stopwatch = Stopwatch.StartNew();

            var fileTasks = files.Select(async file =>
            {
                var lines = await File.ReadAllLinesAsync(file);

                var lineTasks = lines.Select(line =>
                    Task.Run(() => line.Count(c => c == ' '))
                );

                var counts = await Task.WhenAll(lineTasks);
                return counts.Sum();
            });

            var results = await Task.WhenAll(fileTasks);

            stopwatch.Stop();

            Console.WriteLine($"Пробелов: {results.Sum()}");
            Console.WriteLine($"Время: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}
