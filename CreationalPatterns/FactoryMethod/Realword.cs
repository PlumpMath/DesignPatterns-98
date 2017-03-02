using System;

namespace CreationalPatterns.AbstractMethod
{
    public class Realword
    {
        public static void Run()
        {
            var document = new InnerDocument();
            document.DisplayPages();
        }
    }

    public abstract class Page
    {
        public virtual void Description()
        {

        }
    }

    public class WordPage : Page
    {
        public override void Description()
        {
            return "WordPage";
        }
    }

    public class ExcelPage : Page
    {
        public override void Description()
        {
            return "ExcelPage";
        }
    }

    public class PowerPointPage : Page
    {
        public override void Description()
        {
            return "PowerPointPage";
        }
    }

    public abstract class Document
    {
        protected readonly IList<Page> Pages;

        public Document()
        {
            Pages = new List<Page>();
            CreatePages();
        }

        protected abstract void CreatePages();

        public void DisplayPages()
        {
            foreach (var page in Pages)
            {
                Console.WriteLine(page.Description());
            }
        }
    }

    public class InnerDocument : Document
    {
        protected override void CreatePages()
        {
            Pages.Add(new WordPage());
            Pages.Add(new ExcelPage());
            Pages.Add(new PowerPointPage());
        }
    }

    public class OutDocument : Document
    {
        protected override void CreatePages()
        {
            Pages.Add(new WordPage());
            Pages.Add(new ExcelPage());
        }
    }
}
