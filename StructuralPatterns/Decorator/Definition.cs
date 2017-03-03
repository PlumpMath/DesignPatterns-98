using System;
using System.Security.Cryptography;

namespace StructuralPatterns.Decorator
{
    public abstract class Component
    {
        public virtual void Operation()
        {
            Console.WriteLine("basic component operation.");
        }
    }

    public class ConcreateComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Concreate component operation.");
        }
    }

    public class Decorator : Component
    {
        public Component Component { get; set; }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddAction();
        }

        private void AddAction()
        {
            Console.WriteLine("Add some action.");
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddBehavior();
        }

        private void AddBehavior()
        {
            Console.WriteLine("Add some behavior.");
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var component = new ConcreateComponent();
            var decorator = new ConcreteDecoratorA {Component = component};
            decorator.Operation();

            var decorator1 = new ConcreteDecoratorB() {Component = component};
            decorator1.Operation();
        }
    }
}
