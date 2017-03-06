using System;

namespace BehavioralPatterns.Mediator
{
    public abstract class Medicator
    {
        public virtual void Send(string message, College college)
        {
            
        }
    }

    public class ConcreteMediator : Medicator
    {
        public College College1 { get; set; }
        public College College2 { get; set; }

        public override void Send(string message, College college)
        {
            if (college == College1)
            {
                College2.Notify(message);
            }
            else
            {
                College1.Notify(message);
            }
        }
    }

    public abstract class College
    {
        public virtual void Send(string message)
        {
            
        }

        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class ConcreteCollege1 : College
    {
        private readonly Medicator _medicator;

        public ConcreteCollege1(Medicator medicator)
        {
            _medicator = medicator;
        }

        public override void Send(string message)
        {
            _medicator.Send(message, this);
        }
    }

    public class ConcreteCollege2 : College
    {
        private readonly Medicator _medicator;

        public ConcreteCollege2(Medicator medicator)
        {
            _medicator = medicator;
        }

        public override void Send(string message)
        {
            _medicator.Send(message, this);
        }
    }



    public class Definition
    {
        public static void Run()
        {
            var medicator = new ConcreteMediator();
            var college1 = new ConcreteCollege1(medicator);
            var college2 = new ConcreteCollege1(medicator);
            medicator.College1 = college1;
            medicator.College2 = college2;
            college1.Send("hello");
            college2.Send("world");
        }
    }
}
