using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    public class NoteDocument
    {
        public const string ROOT_NAME = "%ROOT";
        public NoteDocument()
        {
            Notes = new List<NoteElement>();
            Notes.Add(new NoteElement(ROOT_NAME));
        }
        public string Title { get; set; }
        public List<NoteElement> Notes;
    }
}
