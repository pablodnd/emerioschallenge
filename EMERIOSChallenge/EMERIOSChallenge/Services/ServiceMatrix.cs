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

        public List<string> ExtractDiagonal(List<string> rows, bool reverse)
        {
            List<string> diagonals = new List<string>();
            int rowsNumber = rows.Count;
            string diagonal = string.Empty;
            int rowCicle = 0;
            int rowNumber = 0;
            int totalCicles = 0;

            while (rowCicle < rowsNumber && totalCicles < rowsNumber)
            {
                while (rowNumber < rowsNumber - rowCicle)
                {
                    if (reverse)
                        diagonal = diagonal + rows[rowNumber]
                            .Reverse()
                            .ElementAt(rowNumber - totalCicles + rowCicle);
                    else
                        diagonal = diagonal + rows[rowNumber]
                            .ElementAt(rowNumber - totalCicles + rowCicle);

                    rowNumber++;
                }

                diagonals.Add(diagonal);
                diagonal = string.Empty;

                rowCicle++;

                if (rowCicle == rowsNumber || totalCicles >= 1)
                {
                    totalCicles++;
                    rowNumber = totalCicles;
                    rowCicle = 0;
                }
                else
                {
                    if (totalCicles < 1)
                        rowNumber = 0;
                }
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
