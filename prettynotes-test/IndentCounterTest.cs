using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using prettynotes;

namespace prettynotes_test
{
    [TestClass]
    public class IndentCounterTest
    {
        [TestMethod]
        public void GetNestLevelTest()
        {
            int lvl = IndentCounter.CountIndent("    ");
            Assert.AreEqual(1, lvl);
            lvl = IndentCounter.CountIndent("\t\t");
            Assert.AreEqual(2, lvl);

            lvl = 0;
            lvl = IndentCounter.CountIndent("        ");
            Assert.AreEqual(2, lvl);
            lvl = IndentCounter.CountIndent("\t");
            Assert.AreEqual(1, lvl);
        }
    }
}
