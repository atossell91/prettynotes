using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using prettynotes;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace prettynotes_test
{
    [TestClass]
    public class NoteFileTest
    {
        [TestMethod]
        public void ParseTest()
        {
            string[] content = new string[]
            {
                "Title",
                "child0",
                "child1",
                "   subchild1-0"
            };
            NoteElement e = NoteFileParser.Parse(content);
            Assert.AreEqual(3, e.ChildCount);
            List<NoteElement> c = e.Children;

            Assert.AreEqual("child0", c[0].Text);
            Assert.AreEqual(0, c[0].ChildCount);

            Assert.AreEqual("child1", c[1].Text);
            Assert.AreEqual(0, c[1].ChildCount);
        }
    }
}
