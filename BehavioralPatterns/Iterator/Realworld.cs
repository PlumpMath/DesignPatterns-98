using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Iterator
{
    public interface IIterator<out T>
    {
        T GetCurrentItem { get; }
        bool IsDone { get; }
        T GetFirst();
        T GetNext();
    }

    public class CollectionIterator : IIterator<string>
    {
        private readonly EnumerableCollection _collection;
        private int _currentIndex;
        public CollectionIterator(EnumerableCollection collection)
        {
            _collection = collection;
        }

        public string GetCurrentItem => _collection[_currentIndex];
        public bool IsDone => _currentIndex >= _collection.Count;

        public string GetFirst()
        {
            return _collection[0];
        }

        public string GetNext()
        {
            if (_currentIndex == _collection.Count - 1)
            {
                _currentIndex++;
                return _collection[_collection.Count - 1];
            }

            if (_currentIndex < _collection.Count)
            {
                return _collection[++_currentIndex];
            }
            return string.Empty;
        }
    }

    public interface IEnumerableCollection<T>
    {
        void Add(T item);
        IIterator<T> GetIterator();
    }

    public class EnumerableCollection:IEnumerableCollection<string>
    {
        private readonly IList<string> _items;

        public EnumerableCollection()
        {
            _items = new List<string>();
        }

        public int Count => _items.Count;

        public string this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public void Add(string item)
        {
            _items.Add(item);
        }

        public IIterator<string> GetIterator()
        {
            return new CollectionIterator(this);
        }
    }


    public class Realworld
    {
        public static void Run()
        {
            var collection = new EnumerableCollection();
            collection.Add("Edison");
            collection.Add("Russel");
            var iterator = collection.GetIterator();
            for (var item = iterator.GetFirst(); !iterator.IsDone; item = iterator.GetNext())
            {
                Console.WriteLine(item);
            }
        }
    }
}
