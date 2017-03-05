using System;

namespace BehavioralPatterns.ChainInResp
{
    public class Definition
    {
        public static void Run()
        {
            var handler1 = new ConcreteHandler1();
            var handler2 = new ConcreteHandler2();
            var handler3 = new ConcreteHandler3();
            
            handler1.Sucessor = handler2;
            handler2.Sucessor = handler3;
            handler1.HandleRequest(-2);
            handler1.HandleRequest(20);
            handler1.HandleRequest(200);
        }
    }

    public abstract class Handler
    {
        public Handler Sucessor { get; set; }

        public abstract void HandleRequest(int amount);
    }

    public class ConcreteHandler1:Handler
    {
        public override void HandleRequest(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine($"{GetType().Name} handle the request.");
            }
            else
            {
                Sucessor?.HandleRequest(amount);
            }
        }
    }

    public class ConcreteHandler2:Handler
    {

        public override void HandleRequest(int amount)
        {
            if (amount > 0 && amount < 10)
            {
                Console.WriteLine($"{GetType().Name} handle the request.");
            }
            else
            {
                Sucessor?.HandleRequest(amount);
            }
        }
    }

    public class ConcreteHandler3:Handler
    {
        public override void HandleRequest(int amount)
        {
            if (amount >= 10)
            {
                Console.WriteLine($"{GetType().Name} handle the request.");
            }
            else
            {
                Sucessor?.HandleRequest(amount);
            }
        }
    }
}
