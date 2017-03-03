using System;
using System.Collections.Generic;

namespace StructuralPatterns.Composite
{
    public abstract class Element
    {
        protected Element(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public abstract void Add(Element element);

        public abstract void Remvoe(Element element);

        public abstract void Display(int depth);
    }

    public class PrimitiveElement : Element
    {
        public PrimitiveElement(string name) : base(name)
        {

        }

        public override void Add(Element element)
        {
            
        }

        public override void Remvoe(Element element)
        {
            
        }

        public override void Display(int depth)
        {
            
        }
    }

    public class CompositeElement : Element
    {
        private readonly IList<Element> _elements;

        public CompositeElement(string name) : base(name)
        {
            _elements = new List<Element>();
        }

        public override void Add(Element element)
        {
            _elements.Add(element);
        }

        public override void Remvoe(Element element)
        {
            _elements.Add(element);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
            foreach (var element in _elements)
            {
                element.Display(depth + 2);
            }
        }
    }

    public class Realword
    {
        public static void Run()
        {
            var compositeElement = new CompositeElement("Shapes");
            compositeElement.Add(new PrimitiveElement("Leaf1"));
            compositeElement.Add(new PrimitiveElement("Leaf2"));
            compositeElement.Add(new CompositeElement("Line1"));
            compositeElement.Add(new CompositeElement("Line1"));
            var childElement = new CompositeElement("Circle");
            childElement.Add(new PrimitiveElement("CircleLeaf1"));
            childElement.Add(new CompositeElement("Circle1"));
            compositeElement.Add(childElement);
            compositeElement.Display(1);
        }
    }
}
