using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EMERIOSChallenge
{
    public class MainProgram : IMainProgram
    {
        private readonly IServiceIO _serviceIO;
        private readonly IServiceMatrix _serviceMatrix;
        private readonly IStringsHelper _stringHelper;
        private readonly ICustomConfiguration _customConfiguration;

        public MainProgram(IServiceIO serviceIO, IServiceMatrix serviceMatrix, IStringsHelper stringHelper, ICustomConfiguration customConfiguration)
        {
            this._serviceIO = serviceIO;
            this._serviceMatrix = serviceMatrix;
            this._stringHelper = stringHelper;
            this._customConfiguration = customConfiguration;
        }

        public void Execute()
        {
            Stopwatch stopwatch = new Stopwatch();
            string path = this._customConfiguration.Path;

            Console.WriteLine($"Loading Matrix from file in {path}");
            stopwatch.Start();
            string matrix = this._serviceIO.ReadFile(path);

            if (string.IsNullOrEmpty(matrix))
            {
                Console.WriteLine($"Nothing found. Quiting");
                return;
            }

            // Print
            Console.WriteLine($"Matrix: ");
            Console.WriteLine(matrix);
            Console.WriteLine($"Start calculating...");

            List<string> rows = _serviceMatrix.ExtractRows(matrix);
            List<string> cols = _serviceMatrix.ExtractColumns(rows, matrix);
            List<string> diagonals = _serviceMatrix.ExtractDiagonal(rows, false);
            List<string> diagonalsReverse = _serviceMatrix.ExtractDiagonal(rows, true);

            List<Tuple<char, int>> ocurrencies = new List<Tuple<char, int>>();

            foreach (var row in rows)
            {
                Tuple<char, int> result = this._stringHelper.GetRepetitiveChars(row);
                ocurrencies.Add(result);
            }

            foreach (var col in cols)
            {
                Tuple<char, int> result = this._stringHelper.GetRepetitiveChars(col);
                ocurrencies.Add(result);
            }

            foreach (var diagonal in diagonals)
            {
                Tuple<char, int> result = this._stringHelper.GetRepetitiveChars(diagonal);
                ocurrencies.Add(result);
            }

            foreach (var diagonal in diagonalsReverse)
            {
                Tuple<char, int> result = this._stringHelper.GetRepetitiveChars(diagonal);
                ocurrencies.Add(result);
            }

            Tuple<char, int> mayor = ocurrencies.OrderByDescending(t => t.Item2).First();
            stopwatch.Stop();

            Console.WriteLine($"Result completed in {stopwatch.Elapsed.TotalSeconds} seconds");
            Console.WriteLine($"Adyacency found: char: {mayor.Item1} - {mayor.Item2} times");
        }
    }
}
