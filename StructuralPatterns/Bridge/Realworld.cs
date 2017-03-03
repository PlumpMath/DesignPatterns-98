using System;

namespace StructuralPatterns.Bridge
{
    public interface IDrinkable
    {
        void Drink();
    }

    public class ManDrink : IDrinkable
    {
        public void Drink()
        {
            Console.WriteLine("Drink Green Tea.");
        }
    }

    public class WomanDrink : IDrinkable
    {
        public void Drink()
        {
            Console.WriteLine("Drink Red Tea.");
        }
    }

    public abstract class Human
    {
        public IDrinkable DrinkBehavior { get; set; }

        public virtual void DoAction()
        {
            
        }
    }

    public class Man : Human
    {
        public override void DoAction()
        {
            Console.Write("Man ");
            DrinkBehavior.Drink();
        }
    }

    public class Woman : Human
    {
        public override void DoAction()
        {
            Console.Write("Woman ");
            DrinkBehavior.Drink();
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var human = new Man {DrinkBehavior = new ManDrink()};
            human.DoAction();

            human.DrinkBehavior = new WomanDrink();
            human.DoAction();
        }
    }
}
