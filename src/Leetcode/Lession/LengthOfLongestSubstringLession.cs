using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Lession
{
    class LengthOfLongestSubstringLession : ILession
    {
        public void Execute()
        {
            //Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
            // Console.WriteLine(LengthOfLongestSubstring("bbbbb"));
            Console.WriteLine(LengthOfLongestSubstring(" "));
        }

        public int LengthOfLongestSubstring(string s)
        {
            System.Collections.BitArray bitArray = new System.Collections.BitArray(256);
            int len = 0;
            int maxlen = 0;
            int current = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var ch = (int)s[i];
                if (bitArray[ch])
                {
                    bitArray = new System.Collections.BitArray(256);
                    len = i - current;
                    if (maxlen < len) maxlen = len;
                    len = 0;
                    i = current;
                    current = current + 1;
                }
                else
                {
                    bitArray[ch] = true;
                }
            }
            len = s.Length - current;
            if (maxlen < len) maxlen = len;
            return maxlen;
        }
    }
}
