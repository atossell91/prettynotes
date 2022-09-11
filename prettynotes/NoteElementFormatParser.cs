using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    class NoteElementFormatParser
    {
        static char HEADER_MARKER = '!';

        public NoteElementFormatParser(string input)
        {
            FormatInfo = new NoteElementFormatInformation();
            RemoveLeadingSpaces(input);
            CountHeaderLevel(ParsedString);
            FormatInfo.FormatStyle = NoteElementFormatInformation.Style.Header;
        }

        public string ParsedString { get; private set; }
        public NoteElementFormatInformation FormatInfo { get; private set; }

        private void RemoveLeadingSpaces(string str)
        {
            int n = 0;
            for (; n < str.Length && Char.IsWhiteSpace(str[n]); ++n);
            ParsedString = str.Substring(n, str.Length - n);
        }
        private void CountHeaderLevel(string str)
        {
            int count = 0;
            for (; count < str.Length && str[count] == HEADER_MARKER; ++count);
            ParsedString = ParsedString.Substring(count, ParsedString.Length - count);
            FormatInfo.HeaderLevel = count;
        }
    }
}
