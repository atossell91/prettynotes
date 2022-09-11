using System;
using prettynotes;

namespace RuntimeTester
{
    class Program
    {
        static void Main(string[] args)
        {
            TexHelper th = new TexHelper();
            Console.WriteLine(th.GetNoteElement("header",
                "\\item a"));
            Console.WriteLine("I like fat girls");
            Console.ReadKey();
        }
    }
}
