using System;

namespace BehavioralPatterns.Category
{
    public abstract class Category
    {
        public abstract void AlgorithmInterface();
    }

    public class ConcreteCategory1 : Category
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine($"{GetType().Name} algorithm interface.");
        }
    }

    public class ConcreteCategory2:Category
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine($"{GetType().Name} algorithm interface.");
        }
    }

    public class Context
    {
        private readonly Category _category;

        public Context(Category category)
        {
            _category = category;
        }

        public Category Category { get; set; }

        public void ContextInterface()
        {
            _category.AlgorithmInterface();
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var context = new Context(new ConcreteCategory1());
            context.ContextInterface();
        }
    }
}
