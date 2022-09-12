using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    public class NoteElement : ITeXable
    {
        public NoteElement() {
            childNotes = new List<NoteElement>();
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
        public int ChildCount { get; private set; } = 0;

        public bool HasParent { get; private set; }
        List<NoteElement> childNotes;
        public List<NoteElement> Children
        {
            get
            {
                return childNotes;
            }
        }

        public void AddChild(NoteElement e)
        {
            e.Parent = this;
            childNotes.Add(e);
            ++ChildCount;
        }
        public bool HasChildren()
        {
            return childNotes.Count > 0;
        }
        public NoteElement GetLastChild()
        {
            if (childNotes.Count < 1)
            {
                return null;
            }
            else
            {
                return childNotes[childNotes.Count-1];
            }
        }
        public string GetTeX()
        {
            throw new NotImplementedException();
        }
    }
}
