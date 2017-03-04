using System;

namespace StructuralPatterns.Proxy
{
    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject:Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called real subject request method.");
        }
    }

    public class Proxy:Subject
    {
        private readonly Subject _subject = new RealSubject();

        public override void Request()
        {
            Console.WriteLine("Proxy request method is called.");
            _subject.Request();
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var proxy = new Proxy();
            proxy.Request();
        }
    }
}
