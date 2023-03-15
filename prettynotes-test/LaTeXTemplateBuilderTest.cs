using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using prettynotes.LaTeX;
using prettynotes;
using System.Linq;
using System.Text.RegularExpressions;

namespace prettynotes_test
{
    [TestClass]
    public class LaTeXTemplateBuilderTest
    {
        [TestMethod]
        public void EscapeCurlyBracketsTest()
        {
            var builder = new LaTeXTemplateBuilder();
            Assert.AreEqual("{{hello}}", builder.EscapeCurlyBrackets("{hello}"));
        }

        [TestMethod]
        public void CreateTemplateTest()
        {
            LaTeXTemplateBuilder b = new LaTeXTemplateBuilder();
            DocumentTemplate d = b.CreateTemplate();
            Console.WriteLine(d.Text);
            Assert.IsNotNull(d);
            Assert.IsTrue(d.Text.Length > 0);
            string searchExpr = @"\\begin\s*\{\{\s*document\s*\}\}";
            Assert.IsTrue(Regex.Match(d.Text, searchExpr).Success);
        }
    }
}
