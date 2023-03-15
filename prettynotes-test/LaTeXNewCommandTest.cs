using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using prettynotes.LaTeX;

namespace prettynotes_test
{
    [TestClass]
    public class LaTeXNewCommandTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            LaTeXNewCommand lnc = new LaTeXNewCommand(@"mycommand", 1, "#1");
            Assert.AreEqual(@"\newcommand{\mycommand}[1]{#1}",lnc.ToString());
        }
    }
}
