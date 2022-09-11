using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace prettynotes
{
    public class LaTeXCommand : ITeXable
    {
        static string DEFINITION_FORMAT = "\\{0}[{1}]{2}";

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("numArguments")]
        public int NumArguments { get; set; }

        [JsonPropertyName("definition")]
        public string Definition { get; set; }

        public string GetDefinition()
        {
            return String.Format(DEFINITION_FORMAT,
                new string[] { Name, NumArguments.ToString(), Definition });
        }
        public string GetCall()
        {
            string tex = "\\" + Name;
            for (int n =0; n < NumArguments; ++n)
            {
                tex += "{{{" + n + "}}}";
            }
            return tex;
        }
        public string GetTeX()
        {
            throw new NotImplementedException();
        }
    }
}
