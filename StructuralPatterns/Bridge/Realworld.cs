using System;

namespace StructuralPatterns.Bridge
{
    public abstract class Tea
    {
        public virtual void Drink() { }
    }

    public class GreenTea : Tea
    {
        public override void Drink()
        {
            Console.WriteLine("Drink Green Tea.");
        }
    }

    public class WomanTea : Tea
    {
        public override void Drink()
        {
            Console.WriteLine("Drink Red Tea.");
        }
    }

    public abstract class Human
    {
        public Tea Meterial { get; set; }

        public virtual void DoAction()
        {
            
        }
    }

    public class Man : Human
    {
        public override void DoAction()
        {
            Console.Write("Man ");
            Meterial.Drink();
        }
    }

    public class Woman : Human
    {
        public override void DoAction()
        {
            Console.Write("Woman ");
            Meterial.Drink();
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var human = new Man { Meterial = new GreenTea()};
            human.DoAction();

            human.Meterial = new WomanTea();
            human.DoAction();
        }
    }
}
