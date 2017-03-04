using System;

namespace BehavioralPatterns.State
{
    public interface IBalanceOperation
    {
        void Deposit(double amount);

        void Withdraw(double amount);

        void PayInterest();
    }

    public abstract class State : IBalanceOperation
    {
        public Account Account { get; protected set; }

        public double Balance { get; protected set; }

        public double Interest { get; protected set; }

        public double LowerLimit { get; protected set; }

        public double UpperLimit { get; protected set; }

        public void Deposit(double amount)
        {
            DepositCore(amount);
            StateChangeCheck();
        }

        public void Withdraw(double amount)
        {
            WithdrawCore(amount);
            StateChangeCheck();
        }

        public void PayInterest()
        {
            PayInterestCore();
            StateChangeCheck();
        }

        protected virtual void DepositCore(double amount)
        {

        }

        protected virtual void WithdrawCore(double amount)
        {
            
        }

        protected virtual void PayInterestCore()
        {
            
        }

        protected virtual void Initialize()
        {
            
        }

        protected virtual void StateChangeCheck()
        {
            
        }

    }

    public class RedState : State
    {
        private double _serviceFee;

        public RedState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            Initialize();
        }

        protected override void DepositCore(double amount)
        {
            Balance += amount;
        }

        protected override void WithdrawCore(double amount)
        {
            amount -= _serviceFee;
            Console.WriteLine("No funds available for withdraw!");
        }

        protected override void PayInterestCore()
        {
            //No interst is paid.
        }

        protected sealed override void Initialize()
        {
            Interest = 0;
            LowerLimit = -100;
            UpperLimit = 0;
            _serviceFee = 15;
        }

        protected override void StateChangeCheck()
        {
            if (Balance > UpperLimit)
                Account.State = new SilverState(this);
        }
    }

    public class SilverState : State
    {
        public SilverState(State state)
            : this(state.Balance, state.Account)
        {
        }

        public SilverState(double balance, Account account)
        {
            Balance = balance;
            Account = account;
            Initialize();
        }

        protected override void DepositCore(double amount)
        {
            Balance += amount;
        }

        protected override void WithdrawCore(double amount)
        {
            Balance -= amount;
        }

        protected override void PayInterestCore()
        {
            Balance += Interest * Balance;
        }

        protected sealed override void Initialize()
        {
            Interest = 0;
            LowerLimit = 0;
            UpperLimit = 1000;
        }

        protected override void StateChangeCheck()
        {
            if (Balance < LowerLimit)
                Account.State = new RedState(this);
            else if (Balance > UpperLimit)
                Account.State = new GoldState(this);
        }
    }

    public class GoldState : State
    {
        public GoldState(State state)
            : this(state.Balance, state.Account)
        {
        }

        public GoldState(double balance, Account account)
        {
            Balance = balance;
            Account = account;
            Initialize();
        }

        protected override void DepositCore(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        protected override void WithdrawCore(double amount)
        {
            Balance -= amount;
            base.Deposit(Balance);
        }

        protected override void PayInterestCore()
        {
            Balance += Interest * Balance;
        }

        protected sealed override void Initialize()
        {
            Interest = 0.05;
            LowerLimit = 1000;
            UpperLimit = 1000000;
        }

        protected virtual void StateChangeCheck()
        {
            if (Balance < 0)
                Account.State = new RedState(this);
            else if (Balance < LowerLimit)
                Account.State = new SilverState(this);
        }
    }

    public class Account : IBalanceOperation
    {
        public Account(string owner)
        {
            Owner = owner;
            State = new SilverState(0, this);
        }

        public string Owner { get; }

        public double Balance => State.Balance;

        public State State { get; set; }

        public void Deposit(double amount)
        {
            State.Deposit(amount);
            Console.WriteLine("Deposited {0:C}--", amount);
            Console.WriteLine("Balance = {0:C}", Balance);
            Console.WriteLine("State = {0}", State.GetType().Name);
            Console.WriteLine("");
        }

        public void Withdraw(double amount)
        {
            State.Withdraw(amount);
            Console.WriteLine("Withdraw {0:C}", amount);
            Console.WriteLine("Balance = {0:C}", Balance);
            Console.WriteLine("State = {0}", State.GetType().Name);
            Console.WriteLine("");
        }

        public void PayInterest()
        {
            State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine("Balance = {0:C}", Balance);
            Console.WriteLine("State = {0}", State.GetType().Name);
            Console.WriteLine("");
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var account = new Account("Edison");

            account.Deposit(500);
            account.Deposit(300);
            account.Deposit(200);
            account.PayInterest();
            account.Withdraw(2000);
            account.Withdraw(1000);
            account.Deposit(600000000);
            account.PayInterest();
        }
    }
}
