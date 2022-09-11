using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    public static class IndentCounter
    {
        static int SPACES = 4;

        public static int CountIndent(string txt)
        {
            int spaceCount = 0;
            int tabCount = 0;
            for (int n = 0; n < txt.Length &&
                (txt[n] == ' ' || txt[n] == '\t'); ++n)
            {
                char c = txt[n];
                if (c == '\t')
                {
                    ++tabCount;
                }
                else if (c == ' ')
                {
                    ++spaceCount;
                }
            }
            return (int)(spaceCount / SPACES + tabCount);
        }
    }
}
