using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    internal class DocumentTemplate
    {
        public DocumentTemplate(string text, int numInsertionPoint)
        {
            Text = text;
            NumInsertionPoint = numInsertionPoint;
        }

        public string Text { get; private set; }
        public int NumInsertionPoint { get; private set; }
    }
}
