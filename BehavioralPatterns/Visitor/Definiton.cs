using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Visitor
{
    public abstract class Vistor
    {
        public virtual void Viste(Element element)
        {
            element.Display();
        }
    }

    public class ConcreteVisitor1 : Vistor
    {
        public override void Viste(Element element)
        {
            Console.WriteLine($"{GetType().Name} is called.");
            base.Viste(element);
        }
    }

    public class ConcreteVisitor2 : Vistor
    {
        public override void Viste(Element element)
        {
            Console.WriteLine($"{GetType().Name} is called.");
            base.Viste(element);
        }
    }

    public abstract class Element
    {
        protected Element(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public void Accept(Vistor vistor)
        {
            vistor.Viste(this);
        }

        public void Display()
        {
            Console.WriteLine($"{GetType().Name}");
        }
    }

    public class ConcreteElement1 : Element
    {
        public ConcreteElement1(string name) : base(name)
        {
        }
    }

    public class ConcreteElement2 : Element
    {
        public ConcreteElement2(string name) : base(name)
        {
        }
    }

    public class VisitObjectStructure
    {
        private readonly IList<Element> _elements = new List<Element>();

        public void Visit(Vistor vistor)
        {
            foreach (var element in _elements)
            {
                element.Accept(vistor);
            }
        }

        public void Add(Element element)
        {
            _elements.Add(element);
        }
    }

    public class Definiton
    {
        public static void Run()
        {
            var structure = new VisitObjectStructure();
            structure.Add(new ConcreteElement1("C1"));
            structure.Add(new ConcreteElement1("C2"));
            structure.Visit(new ConcreteVisitor1());

        }
    }
}
