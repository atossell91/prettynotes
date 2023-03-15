using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes.LaTeX
{
    internal class LaTexRenewCommand
    {
        public static string RENEW_COMMAND_FORMAT = @"\renewcommand{{\{0}}}{{{1}}}";

        public LaTexRenewCommand(string name, string value)
        {
            Name= name;
            Value= value;
        }

        public string Name { get; private set; }
        public string Value { get; private set; }

        public override string ToString()
        {
            return String.Format(RENEW_COMMAND_FORMAT, Name, Value);
        }
    }
}
