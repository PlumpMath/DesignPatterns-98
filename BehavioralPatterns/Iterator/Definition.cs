using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Iterator
{
    public abstract class Aggregate<T>
    {
        protected IList<T> Items { get; set; }

        public abstract int Count { get; }
        public abstract T this[int index] { get; set; }
        public abstract Iterator<T> CreateIterator();

        public void Add(T item)
        {
            Items.Add(item);
        }
    }

    public class ConcreteAggregate : Aggregate<string>
    {
        public ConcreteAggregate()
        {
            Items = new List<string>();
        }

        public override int Count => Items.Count;

        public override Iterator<string> CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public override string this[int index]
        {
            get { return Items[index]; }
            set { Items[index] = value; }
        }
    }

    public abstract class Iterator<T>
    {
        public abstract bool IsDone { get; }
        public abstract T GetCurrentItem { get; }
        public abstract T GetFirst();
        public abstract T GetNext();
    }

    public class ConcreteIterator : Iterator<string>
    {
        private readonly Aggregate<string> _target;
        private int _currentIndex = 0;

        public ConcreteIterator(Aggregate<string> target)
        {
            _target = target;
        }

        public override string GetCurrentItem => _target[_currentIndex];

        public override bool IsDone => _currentIndex >= _target.Count;

        public override string GetFirst()
        {
            return _target[0];
        }

        public override string GetNext()
        {
            return _currentIndex < _target.Count - 1 ? _target[++_currentIndex] : string.Empty;
        }
    }

    internal class Definition
    {
        public static void Run()
        {
            var aggregate = new ConcreteAggregate();
            aggregate.Add("Item1");
            aggregate.Add("Item2");
            aggregate.Add("Item3");
            aggregate.Add("Item4");
            aggregate.Add("Item5");
            var iterator = aggregate.CreateIterator();
            var item = iterator.GetFirst();
            while (!string.IsNullOrEmpty(item))
            {
                Console.WriteLine(iterator.GetCurrentItem);
                item = iterator.GetNext();
            }
        }
    }
}
