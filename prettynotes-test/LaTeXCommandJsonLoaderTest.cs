using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using prettynotes;
using System.Collections.Generic;

namespace prettynotes_test
{
    [TestClass]
    public class LaTeXCommandJsonLoaderTest
    {
        [TestMethod]
        public void GetCommandsTest()
        {
            LaTeXCommandJsonLoader loader = new LaTeXCommandJsonLoader();
            Assert.AreEqual(null, loader.Commands);
            loader.GetCommands();
            List<LaTeXCommand> Commands = loader.Commands;
            Assert.AreEqual(2, Commands.Count);
            Assert.AreEqual("Header", Commands[0].Name);
            Assert.AreEqual(1, Commands[0].NumArguments);
            Assert.AreEqual("{\\textbf{#1}}", Commands[0].Definition);

            Assert.AreEqual("NoteElement", Commands[1].Name);
            Assert.AreEqual(2, Commands[1].NumArguments);
            string def = "{#1 \\begin{itemize}#2 \\end{itemize}}";
            Assert.AreEqual(def, Commands[1].Definition);

        }
    }
}
