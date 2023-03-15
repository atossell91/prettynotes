using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using prettynotes.LaTeX;

namespace prettynotes_test
{
    [TestClass]
    public class LaTeXPackageTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            LaTeXPackage lpt = new LaTeXPackage("amssymb");
            Assert.AreEqual(@"\usepackage{amssymb}", lpt.ToString());
        }
    }
}
