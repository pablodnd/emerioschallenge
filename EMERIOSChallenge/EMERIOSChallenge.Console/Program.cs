using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EMERIOSChallenge.Program
{
    public static class Program
    {
        static void Main()
        {
            // Lectura desde file
            string loadedMatrix = LoadMatrixFromFile("C:/Temp/matrix.txt");

            if (string.IsNullOrEmpty(loadedMatrix))
                return;

            // Modelo basado en strings
            var primeraFila = loadedMatrix.Split("\r\n").First().Split(',');

            // lleno las filas 
            List<string> filas = loadedMatrix.Split("\r\n").Select(a=>a.Replace(", ", string.Empty)).ToList();
            List<string> columnas = new List<string>();
            List<string> diagonalesIzqADer = new List<string>();
            List<string> diagonalesDerAIzq = new List<string>();

            // lleno las columnas
            for(int i = 0; i < primeraFila.Length; i++)
            {
                var elementos = filas.Select(f => f.ElementAt(i));
                columnas.Add(string.Join("", elementos));
            }

            string diagonal = string.Empty;
            // Lleno las diagonales
            // izq a der
            int cicloFila = 0;
            bool cicloCompleto = false;
            int numeroFila = 0;
            int j = 0;
            int ciclosTotales = 0;

            while(cicloFila < filas.Count && ciclosTotales < filas.Count)
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
           
            
            
 

            // der a izq

            // Creacion de matriz
            Matrix matrix = CreateMatrixFromString(loadedMatrix);
            
            // Busqueda de adyacencia



            // Print
            Console.WriteLine($"Matrix: ");
            Console.WriteLine(loadedMatrix);
        }

        static string LoadMatrixFromFile(string path)
        {
            using (StreamReader stream = File.OpenText(path))
            {
                return stream.ReadToEnd();
            }
        }

        static Matrix CreateMatrixFromString(string matrix)
        {
            var rows = GetRows(matrix);
            var rowsNumber = GetRows(matrix).Length;
            var colsNumber = GetCols(GetRows(matrix).First()).Length;

            Matrix newMatrix = new Matrix(rowsNumber, colsNumber);

            for (int f = 0; f < rows.Length; f++)
            { 
                for (int c = 0; c < colsNumber; c++)
                {
                    newMatrix.AddElement(f, c, GetCols(rows[f])[c]);
                }
            }
            
            return newMatrix;
        }

        static string[] GetRows(string matrix)
        {
            return matrix.Split("\r\n");   
        }

        static string[] GetCols(string row)
        {
            return row.Split(',');
        }

        public class Matrix
        {
            private readonly string[,] _elements;
            
            public Matrix(int rows, int columns)
            {
                _elements = new string[rows,columns];
            }

            public void AddElement(int rowNumber, int colNumber, string element)
            {
                _elements[rowNumber, colNumber] = element;
            }

            public string[,] GetAll()
            {
                return _elements;
            }

            public string GetElementAt(int row, int col)
            {
                return _elements[row, col];
            }

            public void FindBestAdyacency()
            {

            }
        }
    }
}
