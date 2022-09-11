using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using prettynotes;

namespace prettynotes_test
{
    [TestClass]
    public class TexHelperTest
    {
        [TestMethod]
        public void GetHeaderTest()
        {
            TexHelper th = new TexHelper();
            Assert.AreEqual("\\Header{The content is here}",
                th.GetHeader("The content is here"));
        }
        [TestMethod]
        public void GetNoteElementTest()
        {
            TexHelper th = new TexHelper();
            Assert.AreEqual("\\NoteElement{noteheader}{\\item One \\item Two \\item three}",
                th.GetNoteElement("noteheader", "\\item One \\item Two \\item three"));
        }
    }
}
