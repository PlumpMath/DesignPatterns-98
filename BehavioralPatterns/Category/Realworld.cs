using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Category
{
    public abstract class SortCategory
    {
        public abstract void Sort(IEnumerable<string> list);
    }

    public class QuickSort : SortCategory
    {
        public override void Sort(IEnumerable<string> list)
        {
            Console.WriteLine("quick sort");
        }
    }

    public class ShellSort:SortCategory
    {
        public override void Sort(IEnumerable<string> list)
        {
            Console.WriteLine("shell sort");
        }
    }

    public class BinarySort : SortCategory
    {
        public override void Sort(IEnumerable<string> list)
        {
            Console.WriteLine("binary sort");
        }
    }

    public class SortedList
    {
        private IList<string> _list = new List<string>();
        private SortCategory _sortCategory;

        public void SetSortCategory(SortCategory sortCategory)
        {
            _sortCategory = sortCategory;
        }

        public void Add(string item)
        {
            _list.Add(item);
        }

        public void Sort()
        {
            _sortCategory.Sort(_list);
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var list = new SortedList();
            list.Add("Russel");
            list.Add("Edison");
            list.SetSortCategory(new BinarySort());
            list.Sort();
        }
    }
}
