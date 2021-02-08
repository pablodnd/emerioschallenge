using System.Collections.Generic;

namespace EMERIOSChallenge
{
    /// <summary>
    /// Interface for extracting row, cols and diagonals from a matrix
    /// </summary>
    public interface IServiceMatrix
    {
        List<string> ExtractRows(string matrix);
        List<string> ExtractColumns(List<string> rows, string matrix);
        List<string> ExtractDiagonal(List<string> rows, bool reverse, string matrix);
    }
}
