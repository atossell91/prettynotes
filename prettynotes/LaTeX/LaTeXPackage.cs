using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes.LaTeX
{
    internal class LaTeXPackage
    {
        public static string PACKAGE_FORMAT = @"\usepackage{{{0}}}";

        public LaTeXPackage(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return String.Format(PACKAGE_FORMAT, Name);
        }
    }
}
