using prettynotes.LaTeX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace prettynotes
{
    internal class LaTeXWriter : IOutputWriteable
    {
        NoteElement noteElement;
        public LaTeXWriter(NoteElement ne)
        {
            noteElement = ne;
        }

        const string INDENT = "    ";
        const string DEFUAULT_BLOCK_CLOSE = "}";

        const string ITEM_SPECIFIER = "\\item ";

        const string LIST_BLOCK_START = "\\NoteList {";
        const string LIST_BLOCK_END = DEFUAULT_BLOCK_CLOSE;

        const string LG_NOTE_HEADER_FORMAT = "\\NoteHeaderBig{{{0}}}";
        const string SM_NOTE_HEADER_FORMAT = "\\NoteHeaderSmall{{{0}}}";

        readonly static string[] ESCAPE_SEQS = { "\\\\", "#", "%", "\\$", "&", "_" };
        static char ESCAPE_CHAR = '\\';
        
        public string EscapeSequences(string str)
        {
            string output = str;
            foreach (string esc in ESCAPE_SEQS)
            {
                output = Regex.Replace(output, esc, ESCAPE_CHAR + esc);
            }
            return output;
        }
        
        public string getIndent(int level)
        {
            StringBuilder builder = new StringBuilder();
            for (int n =0; n < level; ++n)
            {
                builder.Append(INDENT);
            }
            return builder.ToString();
        }
        private void prepareOutput(NoteElement elem, StringBuilder sb, int level)
        {
            if (elem.FormatInfo.HeaderLevel > 1)
            {
                sb.AppendFormat(LG_NOTE_HEADER_FORMAT, elem.Text);
                sb.AppendLine(String.Empty);
            }
            else if (elem.FormatInfo.HeaderLevel == 1)
            {
                sb.AppendFormat(SM_NOTE_HEADER_FORMAT, elem.Text);
                sb.AppendLine(String.Empty);
            }
            else
            {
                string prevIndent = getIndent(level - 1);
                string indent = getIndent(level);
                sb.AppendLine(prevIndent + LIST_BLOCK_START);
                sb.AppendLine(indent + ITEM_SPECIFIER + " " + elem.Text);
                foreach (NoteElement child in elem.Children)
                {
                    prepareOutput(child, sb, level + 1);
                }
                sb.AppendLine(prevIndent + LIST_BLOCK_END);
            }
        }
        private string startPrepareOutput()
        {
            StringBuilder sb = new StringBuilder();
            LaTeXTemplateBuilder ltb = new LaTeXTemplateBuilder();

            sb.AppendLine(noteElement.Text + @"\\");
            sb.AppendLine(String.Empty);

            for(int n =0; n < noteElement.ChildCount; ++n)
            {
                NoteElement child = noteElement.Children[n];
                prepareOutput(child, sb, 1);
            }

            string template = ltb.CreateTemplate().Text;
            return String.Format(template, sb.ToString());
        }
        public string Write()
        {
            //  TODO: Remove magic number 0
            string content = startPrepareOutput();
            return content;
        }
    }
}
