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
            NoteElementFormatParser FormatParser = new NoteElementFormatParser(text);
            Text = FormatParser.ParsedString;
            FormatInfo = FormatParser.FormatInfo;
        }

        public NoteElementFormatInformation FormatInfo = new NoteElementFormatInformation();
        public string Text { get; set; }

        private NoteElement parent;
        public NoteElement Parent {
            get { return parent; }
            set
            {
                parent = value;
                HasParent = parent != null;
            }
        }

        public bool HasParent { get; private set; }
        List<NoteElement> ChildNotes;

        public void AddChild(NoteElement e)
        {
            e.Parent = this;
            ChildNotes.Add(e);
        }
        public bool HasChildren()
        {
            return ChildNotes.Count > 0;
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
