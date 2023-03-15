using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using prettynotes.LaTeX;

namespace prettynotes_test
{
    [TestClass]
    public class LaTeXRenewCommandTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            LaTexRenewCommand lrc = new LaTexRenewCommand("command", @"$\func$");
            Assert.AreEqual(@"\renewcommand{command}{$\func$}", lrc.ToString());
        }
    }
}
