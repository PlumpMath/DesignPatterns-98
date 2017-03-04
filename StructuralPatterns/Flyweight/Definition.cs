using System;
using System.Collections.Generic;

namespace StructuralPatterns.Flyweight
{
    public class FlyweightFactory
    {
        private readonly IDictionary<string, Flyweight> _flyweightDict = new Dictionary<string, Flyweight>();
        private static FlyweightFactory _instance;

        public static FlyweightFactory Instance => _instance ?? (_instance = new FlyweightFactory());

        public Flyweight GetFlyweightInstance(string instancName)
        {
            if (string.IsNullOrEmpty(instancName))
            {
                return null;
            }
            if (_flyweightDict.ContainsKey(instancName))
            {
                return _flyweightDict[instancName];
            }

            var instance = new ConcreteFlyweight(instancName);
            _flyweightDict.Add(new KeyValuePair<string, Flyweight>(instancName, instance));
            return instance;
        }
    }

    public abstract class Flyweight
    {
        protected Flyweight(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public abstract void Operation();
    }

    public class ConcreteFlyweight : Flyweight
    {
        public ConcreteFlyweight(string name) : base(name)
        {

        }

        public override void Operation()
        {
            Console.WriteLine($"Current flyweight name is {Name}");
        }
    }

    public class UnsharedConcreteFlyweight : Flyweight
    {
        public UnsharedConcreteFlyweight(string name) : base(name)
        {
        }

        public override void Operation()
        {
            Console.WriteLine($"Current unshared flyweight name is {Name}");
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var flyweight1 = FlyweightFactory.Instance.GetFlyweightInstance("Instance1");
            var flyweight2 = FlyweightFactory.Instance.GetFlyweightInstance("Instance2");
            Console.WriteLine(flyweight1.Name);
            Console.WriteLine(flyweight2.Name);
        }
    }
}
