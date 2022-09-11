using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    public class NoteElement : ITeXable
    {
        public NoteElement() {
            ChildNotes = new List<NoteElement>();
        }

        public NoteElement(string text) : this()
        {
            Text = text;
        }

        public string Text { get; set; }
        public NoteElement Parent { get; set; } = null;
        List<NoteElement> ChildNotes;

        public void AddChild(NoteElement e)
        {
            e.Parent = this;
            ChildNotes.Add(e);
        }
        public NoteElement GetLastChild()
        {
            if (ChildNotes.Count < 1)
            {
                return null;
            }
            else
            {
                return ChildNotes[ChildNotes.Count-1];
            }
        }
        public string GetTeX()
        {
            throw new NotImplementedException();
        }
    }
}
