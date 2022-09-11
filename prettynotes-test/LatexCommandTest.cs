using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using prettynotes;

namespace prettynotes_test
{
    [TestClass]
    public class LatexCommandTest
    {
        [TestMethod]
        public void GetDefinitionTest()
        {
            LaTeXCommand com = new LaTeXCommand();
            com.Name = "Rose";
            com.NumArguments = 2;
            com.Definition = "{#1 #2}";

            Assert.AreEqual("\\Rose[2]{#1 #2}", com.GetDefinition());
        }
        public void GetCallTest()
        {
            LaTeXCommand com = new LaTeXCommand();
            com.Name = "Rose";
            com.NumArguments = 2;
            com.Definition = "{#1 #2}";

            Assert.AreEqual(@"\Rose{{{0}}}{{{1}}}", com.GetCall());
        }
    }
}
