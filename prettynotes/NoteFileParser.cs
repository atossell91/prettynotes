using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace prettynotes
{
    public static class NoteFileParser
    {
        public static NoteElement Parse(string[] filecontent)
        {
            NoteElement root = new NoteElement();
            NoteElement currentElement = root;
            root.Text = filecontent[0];
            int currentIndent = 0;
            for (int n =1; n < filecontent.Length; ++n)
            {
                string line = filecontent[n];

                if (String.IsNullOrWhiteSpace(line)) continue;

                int lineIndent = IndentCounter.CountIndent(line);
                if (lineIndent == currentIndent)
                {
                    currentElement.AddChild(new NoteElement(line));
                }
                else if (lineIndent > currentIndent)
                {
                    currentElement = currentElement.GetLastChild();
                    currentElement.AddChild(new NoteElement(line));
                }
                else if (lineIndent > currentIndent)
                {
                    int lvlDif = lineIndent - currentIndent;
                    for (int l =0; l < lvlDif; ++l)
                    {
                        currentElement = currentElement.Parent;
                    }
                    currentElement.AddChild(new NoteElement(line));
                }
            }
            return root;
        }
    }
}
