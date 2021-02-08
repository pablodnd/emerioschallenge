using System.Collections.Generic;

namespace EMERIOSChallenge
{
    public interface IServiceMatrix
    {
        List<string> ExtractRows(string matrix);
        List<string> ExtractColumns(List<string> rows, string matrix);
        List<string> ExtractDiagonal(List<string> rows, bool reverse);
    }
}
