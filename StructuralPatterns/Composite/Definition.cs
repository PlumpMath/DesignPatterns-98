using System;
using System.Collections.Generic;

namespace StructuralPatterns.Composite
{
    public abstract class Component
    {
        protected Component(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        public abstract void Display(int depth);
    }

    public class Leaf:Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            
        }

        public override void Remove(Component component)
        {
            
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
        }
    }

    public class Composite:Component
    {
        private readonly IList<Component> _components = new List<Component>();

        public Composite(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
            foreach (var component in _components)
            {
                component.Display(depth + 2);
            }
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var composite = new Composite("C1");
            composite.Add(new Composite("C11"));
            composite.Add(new Composite("C12"));
            composite.Add(new Composite("C13"));
            composite.Add(new Leaf("L1"));
            var childComposite = new Composite("C14");
            childComposite.Add(new Leaf("L10"));
            childComposite.Add(new Leaf("L11"));
            composite.Add(childComposite);
            composite.Display(0);
        }
    }
}
