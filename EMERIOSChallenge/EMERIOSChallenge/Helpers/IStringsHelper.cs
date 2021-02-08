using System;

namespace EMERIOSChallenge
{
    public interface IStringsHelper
    {
        Tuple<char, int> GetRepetitiveChars(string input);
        string GetChainFromAdyacensy(char input, int count);
    }
}
