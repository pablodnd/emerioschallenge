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

            List<Tuple<char, int>> ocurrencias = new List<Tuple<char, int>>();

            foreach (var row in rows)
            {
                var resultado = this._stringHelper.GetRepetitiveChars(row);
                ocurrencias.Add(resultado);
            }

            foreach (var col in cols)
            {
                var resultado = this._stringHelper.GetRepetitiveChars(col);
                ocurrencias.Add(resultado);
            }

            foreach (var diagonal in diagonals)
            {
                var resultado = this._stringHelper.GetRepetitiveChars(diagonal);
                ocurrencias.Add(resultado);
            }

            foreach (var diagonal in diagonalsReverse)
            {
                var resultado = this._stringHelper.GetRepetitiveChars(diagonal);
                ocurrencias.Add(resultado);
            }

            Tuple<char, int> mayor = ocurrencias.OrderByDescending(t => t.Item2).First();
            stopwatch.Stop();

            Console.WriteLine($"Result completed in {stopwatch.Elapsed.TotalSeconds} seconds");
            Console.WriteLine($"Adyacency found: char: {mayor.Item1} - {mayor.Item2} times");
        }
    }
}
