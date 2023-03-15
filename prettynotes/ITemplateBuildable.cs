using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes
{
    internal interface ITemplateBuildable
    {
        DocumentTemplate CreateTemplate();
    }
}
