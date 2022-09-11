using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace prettynotes
{
    public class NoteFileParser
    {
        //TODO: Redo this whole algorithm
        //TODO: Don't code until you know what you're doing
        public void parse(string filename)
        {
            // Open, read, and close the file
            string[] lines = File.ReadAllLines(filename);
            
            // Stop if there is less than 1 line
            if (lines.Length < 1)
            {
                return;
            }

            // Set the title (first line is always the title)
            NoteDocument doc = new NoteDocument();
            doc.Title = lines[0];
            NoteElement currentNote = doc.Notes[0];

            // Now perform the algorithm
            int nestLevel = 0;
            for (int n =1; n < lines.Length; ++n)
            {
                string currentLine = lines[n];
                if (String.IsNullOrWhiteSpace(currentLine))
                {
                    //Skip empty lines
                    continue;
                }

                //TODO: Need to handle headers and other modifiers
                int nest = IndentCounter.CountIndent(currentLine);
                if (nest == nestLevel)
                {
                    //If nest values are the same, add to list
                    currentNote.AddChild(new NoteElement(currentLine));
                }
                else if (nest < nestLevel)
                {
                    //If new value is less, move up accordingly
                    int diff = nestLevel - nest;
                    for (int i =0; i < diff; ++i)
                    {
                        if (currentNote.Parent == null)
                        {
                            break;
                        }
                        else
                        {
                            currentNote = currentNote.Parent;
                        }
                    }
                    nestLevel = nest;
                    currentNote.AddChild(new NoteElement(currentLine));
                }
                else if (nest > nestLevel)
                {
                    //If new value is greater, create child
                    NoteElement ne = new NoteElement(currentLine);
                    NoteElement lastChild = currentNote.GetLastChild();
                    if (lastChild == null)
                    {
                        currentNote.AddChild(ne);

                    }
                    nestLevel = nest;
                    currentNote.AddChild(new NoteElement(currentLine));
                }
            }
        }
    }
}
