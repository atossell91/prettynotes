using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args[0];
            string outputfile = args[1];
            if (File.Exists(filename))
            {
                // Run the program
                string[] lines = File.ReadAllLines(filename);
                NoteElement doc = NoteFileParser.Parse(lines);
                LaTeXWriter laTeXWriter = new LaTeXWriter(doc);
                File.WriteAllText(outputfile, laTeXWriter.Write());
            }
            else
            {
                string noFileMsg = "File \"{0}\" could not be found.";
                Console.WriteLine(noFileMsg);
            }
        }
    }
}
