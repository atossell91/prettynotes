using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prettynotes.LaTeX
{
    internal class LaTeXTemplateBuilder : ITemplateBuildable
    {
        static string DOC_CLASS_HEADER = @"\documentclass{article}";
        static string DOC_BEGIN_END = "\\begin{{document}}\r\n{0}\r\n\\end{{document}}";
        public LaTeXTemplateBuilder()
        {
            init();
        }

        List<LaTeXPackage> Packages { get; set; }
        List<LaTexRenewCommand> RenewCommands { get; set; }
        List<LaTeXNewCommand> NewCommands { get; set; }

        void init()
        {
            Packages = new List<LaTeXPackage>()
            {
                new LaTeXPackage("enumitem"),
                new LaTeXPackage("amssymb")
            };

            RenewCommands = new List<LaTexRenewCommand>()
            {
                new LaTexRenewCommand("labelitemi",@"$\blacktriangleright$"),
                new LaTexRenewCommand("labelitemii",@"$\rhd$"),
                new LaTexRenewCommand("labelitemiii",@"$>$"),
                new LaTexRenewCommand("labelitemiv",@"$-$")
            };

            NewCommands = new List<LaTeXNewCommand>()
            {
                new LaTeXNewCommand("NoteHeaderBig", 1,
                "\r\n\r\n    \\begin{Large}\\underline{\\textbf{#1}}\\end{Large} \\\\ \\\\ \r\n"),

                new LaTeXNewCommand("NoteHeaderSmall", 1,
                "\r\n\r\n    \\begin{large}\\textbf{#1}\\end{large} \r\n"),

                new LaTeXNewCommand("NoteDocument", 1,
                "\r\n    \\begin{itemize}[nolistsep, noitemsep, leftmargin=*]\r\n        #1\r\n    \\end{itemize}\r\n"),

                new LaTeXNewCommand("NoteList", 1,
                "\r\n    \\begin{itemize}\r\n        #1\r\n    \\end{itemize}\r\n"),
            };
        }

        public string EscapeCurlyBrackets(string text)
        {
            string left = text.Replace("{", "{{");
            return left.Replace("}", "}}");
        }

        public DocumentTemplate CreateTemplate()
        {
            StringBuilder docString = new StringBuilder();

            docString.AppendLine(EscapeCurlyBrackets(DOC_CLASS_HEADER));
            docString.AppendLine();

            foreach (var package in Packages)
            {
                docString.AppendLine(EscapeCurlyBrackets(package.ToString()));
            }
            docString.AppendLine();

            foreach (var package in RenewCommands)
            {
                docString.AppendLine(EscapeCurlyBrackets(package.ToString()));
            }
            docString.AppendLine();

            foreach (var package in NewCommands)
            {
                docString.AppendLine(EscapeCurlyBrackets(package.ToString()));
            }
            docString.AppendLine();

            docString.AppendLine("\\usepackage[margin=1.0in]{{geometry}}");
            docString.AppendLine();

            docString.AppendLine("\\setlength{{\\parindent}}{{0pt}}");
            docString.AppendLine();

            docString.AppendLine(DOC_BEGIN_END);

            DocumentTemplate documentTemplate = new DocumentTemplate(docString.ToString(), 0);
            return documentTemplate;
        }
    }
}
