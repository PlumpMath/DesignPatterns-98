using System;

namespace StructuralPatterns.Bridge
{
    public abstract class Abstraction
    {
        public Implementor Implementor { get; set; }

        public virtual void Request()
        {
            
        }
    }

    public class RedefinedAbstraction : Abstraction
    {
        public override void Request()
        {
            Console.Write("Redefined ");
            Implementor.Execute();
        }
    }

    public abstract class Implementor
    {
        public virtual void Execute() { }
    }

    public class ImplementorA : Implementor
    {
        public override void Execute()
        {
            Console.WriteLine("Implementor A is executed.");
        }
    }

    public class ImplementorB : Implementor
    {
        public override void Execute()
        {
            Console.WriteLine("Implementor B is executed.");
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var implementor = new ImplementorA();

            var abstraction = new RedefinedAbstraction {Implementor = implementor};

            abstraction.Request();

            abstraction.Implementor = new ImplementorB();
            abstraction.Request();
        }
    }
}
