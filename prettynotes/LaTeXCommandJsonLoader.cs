using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace prettynotes
{
    public class LaTeXCommandJsonLoader
    {
        public LaTeXCommandJsonLoader()
        {
            Commands = null;
        }

        static string JSON_FILE_NAME = "LaTeX-definitions.json";
        public List<LaTeXCommand> Commands { get; private set; }

        public void GetCommands()
        {
            using (TextReader reader = File.OpenText(JSON_FILE_NAME))
            {
                Commands = JsonSerializer.Deserialize<List<LaTeXCommand>>(reader.ReadToEnd());
            }
        }
    }
}
