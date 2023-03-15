using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes.LaTeX
{
    internal class LaTeXNewCommand
    {
        public static string NEW_COMMAND_FORMAT = "\\newcommand{{\\{0}}}{1}{{{2}}}";
        public static string ARG_NUM_FORMAT = "[{0}]";

        public LaTeXNewCommand(string name, int numArgs, string definition)
        {
            Name = name;
            NumArgs = numArgs;
            Definition = definition;
        }
        
        public string Name { get; private set; }
        public int NumArgs { get; private set; } = 0;
        public string Definition { get; private set; }

        public override string ToString()
        {
            string argStr = NumArgs == 0 ? "" : 
                String.Format(ARG_NUM_FORMAT,NumArgs.ToString());
            return String.Format(NEW_COMMAND_FORMAT, new String[] { Name, argStr, Definition});
        }
    }
}
