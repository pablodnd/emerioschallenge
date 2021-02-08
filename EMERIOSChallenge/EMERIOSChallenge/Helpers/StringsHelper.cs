using System;
using System.Text;

namespace EMERIOSChallenge
{
    public class StringsHelper : IStringsHelper
    {
        public StringsHelper()
        { }

        // function to find out the maximum repeating 
        // character in given string 
        public Tuple<char, int> GetRepetitiveChars(string input)
        {
            int length = input.Length;
            int count = 0;

            char occurence = input[0];

            for (int i = 0; i < length; i++)
            {
                int cur_count = 1;
                for (int j = i + 1; j < length; j++)
                {
                    if (input[i] != input[j])
                        break;
                    cur_count++;
                }

                if (cur_count > count)
                {
                    count = cur_count;
                    occurence = input[i];
                }
            }

            return new Tuple<char, int>(occurence, count);
        }

        public string GetChainFromAdyacensy(char input, int count)
        {
            StringBuilder result = new StringBuilder();

            while (count > 0)
            {
                result.Append($"{input},");
                count--;
            }

            return result.ToString().TrimEnd(',');
        }
    }
}
