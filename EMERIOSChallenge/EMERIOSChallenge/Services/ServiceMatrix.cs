using System;
using System.Collections.Generic;
using System.Linq;

namespace EMERIOSChallenge
{
    public class ServiceMatrix : IServiceMatrix
    {
        public ServiceMatrix()
        { }

        public List<string> ExtractColumns(List<string> rows, string matrix)
        {
            List<string> cols = new List<string>();

            var firstRow = matrix.Split(new string[] { "\r\n" }, StringSplitOptions.None).First().Split(',');

            for (int i = 0; i < firstRow.Length; i++)
            {
                var elementos = rows.Select(f => f.ElementAt(i));
                cols.Add(string.Join(string.Empty, elementos));
            }

            return cols;
        }

        public List<string> ExtractDiagonal(List<string> rows, bool reverse, string matrix)
        {
            List<string> diagonals = new List<string>();
            int colsCount = ExtractColumns(rows, matrix).Count;
            int rowsCount = rows.Count;
            string diagonal = string.Empty;
            int row = 0;
            int colIndex;
            int cicle = 0;
            int expectedTotalCicles = colsCount + rowsCount - 1;

            while (cicle < rowsCount)
            {
                for (colIndex = cicle; colIndex < colsCount && row < (rowsCount - cicle); colIndex++)
                {
                    if (reverse)
                    {
                        diagonal = diagonal + rows[row].Reverse().ElementAt(colIndex);
                    }
                    else
                    {
                        diagonal = diagonal + rows[row].ElementAt(colIndex);
                    }

                    row++;
                }

                diagonals.Add(diagonal);
                diagonal = string.Empty;
                cicle++;
                expectedTotalCicles--;
                row = 0;
            }

            // reset cicle
            cicle = 0;

            while (cicle < rowsCount - 1)
            {
                // go to next row
                row = cicle + 1;
                while (row < rowsCount)
                {
                    if (reverse)
                    {
                        diagonal = diagonal + rows[row].Reverse().ElementAt(row - cicle - 1);
                    }
                    else
                    {
                        diagonal = diagonal + rows[row].ElementAt(row - cicle - 1);
                    }
                    
                    row++;
                
                }

                diagonals.Add(diagonal);
                diagonal = string.Empty;
                cicle++;
            }

            return diagonals;
        }

        public List<string> ExtractRows(string matrix)
        {
            return matrix
                .Split(new string[] { "\r\n" }, StringSplitOptions.None)
                .Select(a => a.Replace(", ", string.Empty))
                .ToList();
        }
    }
}
