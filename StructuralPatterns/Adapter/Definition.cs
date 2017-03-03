using System;

namespace StructuralPatterns.Adapter
{

    public class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("target base request.");
        }
    }

    public class Adapter : Target
    {
        private readonly IAdaptee _adaptee;

        public Adapter(IAdaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public override void Request()
        {
            Console.WriteLine("adapter request was called.");
            base.Request();
            _adaptee.SepcificRequest();
        }
    }

    public interface IAdaptee
    {
        void SepcificRequest();
    }

    public class Adaptee : IAdaptee
    {
        public void SepcificRequest()
        {
            Console.WriteLine("specific request.");
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var target = new Adapter(new Adaptee());
            target.Request();
        }
    }
}
