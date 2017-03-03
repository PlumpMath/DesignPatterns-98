using System;

namespace CreationalPatterns.Singleton
{
    public class Singleton
    {
        private static readonly object LockThis = new object();

        private static Singleton _instance;

        private Singleton()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }

        public static Singleton GetInstance()
        {
            //Avoid locking each time the method invoked, we use the double checked locking pattern
            if (_instance == null)
            {
                lock (LockThis)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }

            return _instance;
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var singleton1 = Singleton.GetInstance();
            var singleton2 = Singleton.GetInstance();

            Console.WriteLine(singleton1.Id);
            Console.WriteLine(singleton2.Id);
        }
    }
}
