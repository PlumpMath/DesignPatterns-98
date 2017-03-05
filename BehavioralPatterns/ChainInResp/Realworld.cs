using System;

namespace BehavioralPatterns.ChainInResp
{
    public abstract class Approver
    {
        protected Approver Successor;

        protected Approver(double threshold)
        {
            Threshold = threshold;
        }

        protected double Threshold { get; }

        public void SetSuccessor(Approver successor)
        {
            Successor = successor;
        }

        public virtual void HandleRequest(Purchase purchase)
        {
            if (purchase.Amount <= Threshold)
            {
                Console.WriteLine($"{GetType().Name} handled {purchase.Amount} purchase.");
            }
            else
            {
                Successor?.HandleRequest(purchase);
            }
        }
    }

    public class Director : Approver
    {
        public Director(double threshold) : base(threshold)
        {
        }

        //TODO: Implement director logic.
        //public override void HandleRequest(Purchase purchase)
        //{

        //}
    }

    public class VicePresident : Approver
    {
        public VicePresident(double threshold) : base(threshold)
        {
        }

        //TODO: Implement vice president logic.
        //public override void HandleRequest(Purchase purchase)
        //{

        //}
    }

    public class President : Approver
    {
        public President(double threshold) : base(threshold)
        {
        }

        //TODO: Implement president logic.
        //public override void HandleRequest(Purchase purchase)
        //{

        //}
    }

    public class Purchase
    {
        public Purchase(string serialNumber, double amount, string purpose)
        {
            SerialNumber = serialNumber;
            Amount = amount;
            Purpose = purpose;
        }

        public string SerialNumber { get; }
        public double Amount { get; }
        public string Purpose { get; }
    }

    public class Realworld
    {
        public static void Run()
        {
            var director = new Director(1000);
            var vicePresident = new VicePresident(10000);
            var president = new President(100000);
            director.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);
            director.HandleRequest(new Purchase("p1", 200, "reson1"));
            director.HandleRequest(new Purchase("p2", 2000, "reson2"));
            director.HandleRequest(new Purchase("p1", 20000, "reson3"));
        }
    }
}
