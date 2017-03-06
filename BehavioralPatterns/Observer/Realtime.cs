using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Observer
{
    public interface IInvestor
    {
        string Name { get; }
        void Update(string symbol, double price);
    }

    public class Investor : IInvestor
    {
        public Investor(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Update(string symbol, double price)
        {
            Console.WriteLine($"{Name} received stock {symbol} price changed event, new price is {price}.");
        }
    }

    public abstract class Stock
    {
        private readonly IList<IInvestor> _investors;

        protected Stock(string symbol)
        {
            _investors = new List<IInvestor>();
            Symbol = symbol;
        }

        public string Symbol { get; }

        public virtual double Price { get; set; }

        public void Attach(IInvestor investor)
        {
            _investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            _investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (var investor in _investors)
            {
                investor.Update(Symbol, Price);
            }
        }
    }
    
    public class IBM:Stock
    {
        private double _price;

        public IBM(string symbol) : base(symbol)
        {
        }

        public override double Price
        {
            get { return _price;}
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }
    }

    public class Realtime
    {
        public static void Run()
        {
            var stock = new IBM("IBM");
            stock.Attach(new Investor("investor 1."));
            stock.Attach(new Investor("investor 2."));
            stock.Attach(new Investor("investor 3."));
            stock.Price = 100;
        }
    }
}
