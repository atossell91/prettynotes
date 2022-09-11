using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    public class NoteElementFormatInformation
    {
        public enum Style { Regular, Header, Title};

        public NoteElementFormatInformation()
        {
        }

        public Style FormatStyle = Style.Regular;
        public int HeaderLevel = 0;
    }
}
