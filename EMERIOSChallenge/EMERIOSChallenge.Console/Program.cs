using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;

namespace EMERIOSChallenge.Program
{
    public static class Program
    {
        static void Main()
        {
            string path = "C:/Temp/matrix.txt";

            Console.WriteLine($"Loading Matrix from file in {path}");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Lectura desde file
            string loadedMatrix = LoadMatrixFromFile(path);

            if (string.IsNullOrEmpty(loadedMatrix))
            {
                Console.WriteLine($"Nothing found. Quiting");
                return;
            }

            // Print
            Console.WriteLine($"Matrix: ");
            Console.WriteLine(loadedMatrix);

            Console.WriteLine($"Start calculating...");

            // lleno las filas 
            List<string> filas = loadedMatrix.Split("\r\n").Select(a=>a.Replace(", ", string.Empty)).ToList();
            List<string> columnas = CargarColumnas(filas, loadedMatrix);
            List<string> diagonalesIzqADer = CargarDiagonal(filas);
            List<string> diagonalesDerAIzq = CargarDiagonalInversa(filas);

            //obtener adyacentes en filas

            List<Tuple<char, int>> ocurrencias = new List<Tuple<char, int>>();
            foreach (var item in filas)
            {
                var resultado = GetRepetitiveChars(item);
                ocurrencias.Add(resultado);
            }

            //obtener adyacentes en columnas

            List<Tuple<char, int>> ocurrenciasEnColumnas = new List<Tuple<char, int>>();
            foreach (var item in columnas)
            {
                var resultado = GetRepetitiveChars(item);
                ocurrencias.Add(resultado);
            }

            //obtener adyacentes en diagonales
            // de izq a der

            List<Tuple<char, int>> ocurrenciasEnDiagonalesIzqADer = new List<Tuple<char, int>>();
            foreach (var item in diagonalesIzqADer)
            {
                var resultado = GetRepetitiveChars(item);
                ocurrencias.Add(resultado);
            }

            // de der a izq
            List<Tuple<char, int>> ocurrenciasEnDiagonalesDerAIZq = new List<Tuple<char, int>>();
            foreach (var item in diagonalesDerAIzq)
            {
                var resultado = GetRepetitiveChars(item);
                ocurrencias.Add(resultado);
            }

            // elemento mayor en diagonales de izq a der
            var mayor = ocurrencias.OrderByDescending(t => t.Item2).First();
            stopwatch.Stop();
            Console.WriteLine($"Result completed in {stopwatch.Elapsed.TotalSeconds} seconds");
            Console.WriteLine($"Adyacency found: char: {mayor.Item1} - {mayor.Item2} times");


        }

        // function to find out the maximum repeating 
        // character in given string 
        static Tuple<char, int> GetRepetitiveChars(string str)
        {
            
            int length = str.Length;
            int count = 0;

            char occurence = str[0];

            for (int i = 0; i < length; i++)
            {
                int cur_count = 1;
                for (int j = i + 1; j < length; j++)
                {
                    if (str[i] != str[j])
                        break;
                    cur_count++;
                }

                if (cur_count > count)
                {
                    count = cur_count;
                    occurence = str[i];
                }
            }

            return new Tuple<char, int>(occurence, count);
        }

        static List<string> CargarColumnas(List<string> filas, string loadedMatrix)
        {
            List<string> columnas = new List<string>();
            // Modelo basado en strings
            var primeraFila = loadedMatrix.Split("\r\n").First().Split(',');
            // lleno las columnas
            for (int i = 0; i < primeraFila.Length; i++)
            {
                var elementos = filas.Select(f => f.ElementAt(i));
                columnas.Add(string.Join("", elementos));
            }

            return columnas;
        }

        static List<string> CargarDiagonal(List<string> filas)
        {
            List<string> diagonalesIzqADer = new List<string>();

            string diagonal = string.Empty;
            // Lleno las diagonales
            // izq a der
            int cicloFila = 0;
            int numeroFila = 0;
            int ciclosTotales = 0;

            while (cicloFila < filas.Count && ciclosTotales < filas.Count)
            {
                while (numeroFila < filas.Count - cicloFila)
                {
                    // fila 0, tomo el valor 0
                    // fila 1, tomo el valor 1,
                    // fila 2, tomo el valor 2... etc.
                    diagonal = diagonal + filas[numeroFila].ElementAt(numeroFila - ciclosTotales + cicloFila);
                    numeroFila++;
                }

                // agrego la diagonal
                diagonalesIzqADer.Add(diagonal);
                diagonal = string.Empty;

                //sumo un ciclo completo de fila
                cicloFila++;

                // si el ciclo de la fila termino
                if (cicloFila == filas.Count || ciclosTotales >= 1)
                {
                    // incremento uno a ciclos totales
                    ciclosTotales++;
                    // avanzo a la fila siguiente
                    numeroFila = ciclosTotales;
                    // reseteo el ciclo de la fila
                    cicloFila = 0;
                }
                else
                {
                    if (ciclosTotales < 1)
                        numeroFila = 0;
                }
            }

            return diagonalesIzqADer;
        }
        static List<string> CargarDiagonalInversa(List<string> filas)
        {
            List<string> diagonalesIzqADer = new List<string>();

            string diagonal = string.Empty;
            // Lleno las diagonales
            // izq a der
            int cicloFila = 0;
            int numeroFila = 0;
            int ciclosTotales = 0;

            while (cicloFila < filas.Count && ciclosTotales < filas.Count)
            {
                while (numeroFila < filas.Count - cicloFila)
                {
                    // fila 0, tomo el valor 0
                    // fila 1, tomo el valor 1,
                    // fila 2, tomo el valor 2... etc.
                    diagonal = diagonal + filas[numeroFila].Reverse().ElementAt(numeroFila - ciclosTotales + cicloFila);
                    numeroFila++;
                }

                // agrego la diagonal
                diagonalesIzqADer.Add(diagonal);
                diagonal = string.Empty;

                //sumo un ciclo completo de fila
                cicloFila++;

                // si el ciclo de la fila termino
                if (cicloFila == filas.Count || ciclosTotales >= 1)
                {
                    // incremento uno a ciclos totales
                    ciclosTotales++;
                    // avanzo a la fila siguiente
                    numeroFila = ciclosTotales;
                    // reseteo el ciclo de la fila
                    cicloFila = 0;
                }
                else
                {
                    if (ciclosTotales < 1)
                        numeroFila = 0;
                }
            }

            return diagonalesIzqADer;
        }

        static string LoadMatrixFromFile(string path)
        {
            using (StreamReader stream = File.OpenText(path))
            {
                return stream.ReadToEnd();
            }
        }
    }
}
