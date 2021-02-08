using System.Collections.Generic;
using System.Linq;

namespace EMERIOSChallenge.Tests
{
    public static class Fakes
    {
        public static string GetDefaultMatrix()
        {
            return "B, B, D, A, D, E, F\r\nB, X, C, D, D, J, K\r\nH, Y, I, 3, D, D, 3\r\nR, 7, O, Ñ, G, D, 2\r\nW, N, S, P, E, 0, D\r\nA, 9, C, D, D, E, F\r\nB, X, D, D, D, J, K";
        }

        public static List<string> GetDefaultListOfRows()
        {
            return Enumerable.Repeat(GetDefaultRow(), 5).ToList();
        }

        public static string GetDefaultRow()
        {
            return "BBDADEF";
        }
    }
}
