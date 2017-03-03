using System;
using System.Collections.Generic;

namespace CreationalPatterns.FactoryMethod
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
        public virtual string Description()
        {
            return string.Empty;
        }
    }

    public class WordPage : Page
    {
        public override string Description()
        {
            return "WordPage";
        }
    }

    public class ExcelPage : Page
    {
        public override string Description()
        {
            return "ExcelPage";
        }
    }

    public class PowerPointPage : Page
    {
        public override string Description()
        {
            return "PowerPointPage";
        }
    }

    public abstract class Document
    {
        protected readonly IList<Page> Pages;

        protected Document()
        {
            Pages = new List<Page>();
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
        public InnerDocument()
        {
            CreatePages();
        }

        protected sealed override void CreatePages()
        {
            Pages.Add(new WordPage());
            Pages.Add(new ExcelPage());
            Pages.Add(new PowerPointPage());
        }
    }

    public class OutDocument : Document
    {
        public OutDocument()
        {
            CreatePages();
        }

        protected sealed override void CreatePages()
        {
            Pages.Add(new WordPage());
            Pages.Add(new ExcelPage());
        }
    }
}
