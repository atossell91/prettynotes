using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace prettynotes
{
    public static class NoteFileParser
    {
        public static NoteElement Parse(string[] filecontent)
        {
            NoteElement root = new NoteElement();
            NoteElement currentElement = root;

            //  TODO: Make sure this line actually has text in it
            root.Text = filecontent[0];

            //  Sets the current indent (Used to determine nesting)
            int currentIndent = 0;
            for (int n =1; n < filecontent.Length; ++n)
            {
                string line = filecontent[n];

                if (String.IsNullOrWhiteSpace(line)) continue;

                int firstCharIndex = 0;

                //  TODO: This does something similar to what the NoteElement constructor does (strips preceding
                //  whitespace). Find a way to combine them
                for (; firstCharIndex < line.Length && Char.IsWhiteSpace(line[firstCharIndex]); ++firstCharIndex);

                //  TODO: This doesn't need to be done if the line starts with '-'
                int lineIndent = IndentCounter.CountIndent(line);
                if (line[firstCharIndex] == '-')
                {
                    int cut = firstCharIndex + 1;
                    string actualLine = " " + line.Substring(cut, line.Length - cut);
                    currentElement.GetLastChild().Text += actualLine;
                }
                else if (lineIndent == currentIndent)
                {
                    currentElement.AddChild(new NoteElement(line));
                }
                else if (lineIndent > currentIndent)
                {
                    currentElement = currentElement.GetLastChild();
                    currentElement.AddChild(new NoteElement(line));
                }
                else if (lineIndent < currentIndent)
                {
                    int lvlDif = currentIndent - lineIndent;
                    Debug.WriteLine("Difference is: " + lvlDif);
                    for (int l =0; l < lvlDif; ++l)
                    {
                        currentElement = currentElement.Parent;
                    }
                    currentElement.AddChild(new NoteElement(line));
                }
                currentIndent = lineIndent;
            }
            return root;
        }
    }
}
