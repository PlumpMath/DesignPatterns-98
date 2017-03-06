using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Observer
{
    public interface IObserver
    {
        void Update();
    }

    public class ConcreteObserver1 : IObserver
    {
        private readonly Subject _subject;

        public ConcreteObserver1(Subject subject)
        {
            _subject = subject;
        }

        public void Update()
        {
            var state = _subject.State;
            Console.WriteLine($"State changed, value:{state}");
        }
    }

    public class ConcreteObserver2 : IObserver
    {
        private readonly Subject _subject;

        public ConcreteObserver2(Subject subject)
        {
            _subject = subject;
        }

        public void Update()
        {
            var state = _subject.State;
            Console.WriteLine($"State changed, value:{state}");
        }
    }

    public abstract class Subject
    {
        private readonly IList<IObserver> _observers;

        protected Subject()
        {
            _observers = new List<IObserver>();
        }

        public virtual string State { get; set; }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public virtual void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    public class ConcreteSubject:Subject
    {
        private string _state;

        public override string State
        {
            get { return _state;}
            set
            {
                if (_state != value)
                {
                    _state = value;
                    Notify();
                }
            }
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var subject = new ConcreteSubject();
            var observer1 = new ConcreteObserver1(subject);
            var observer2 = new ConcreteObserver2(subject);
            subject.Attach(observer1);
            subject.Attach(observer2);
            subject.State = "new value";
        }
    }
}
