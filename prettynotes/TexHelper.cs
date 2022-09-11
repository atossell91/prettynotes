using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    public class TexHelper
    {
        public TexHelper() {
            LoadCommands();
        }

        List<LaTeXCommand> Commands;
        
        private void LoadCommands()
        {
            LaTeXCommandJsonLoader loader = new LaTeXCommandJsonLoader();
            loader.GetCommands();
            Commands = loader.Commands;
        }
        public string GetHeader(string content)
        {
            LaTeXCommand c = Commands.Find((com) => { return com.Name.ToLower() == "header"; });
            return String.Format(c.GetCall(), content);
        }
        public string GetNoteElement(string noteheader, string content)
        {
            LaTeXCommand c = Commands.Find((com) => { return com.Name.ToLower() == "noteelement"; });
            if (c == null)
            {
                return null;
            }
            string call = c.GetCall();
            return String.Format(call, noteheader, content);
        }
    }
}
