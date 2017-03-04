using System;

namespace StructuralPatterns.Facade
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine($"Check bank for {c.Name}");
            return amount > 1000;
        }
    }

    public class Loan
    {
        public bool HasBadLoans(Customer c)
        {
            Console.WriteLine($"Check loans for {c.Name}");
            return false;
        }
    }

    public class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine($"Check credit for {c.Name}");
            return true;
        }
    }

    public class Mortgage
    {
        private readonly Bank _bank = new Bank();
        private readonly Loan _loan = new Loan();
        private readonly Credit _credit = new Credit();

        public bool IsEligible(Customer customer, int amount)
        {
            Console.WriteLine($"{customer.Name} applies for {amount}");

            var eligible = true;

            if (!_bank.HasSufficientSavings(customer, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasBadLoans(customer))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(customer))
            {
                eligible = false;
            }

            return eligible;
        }
    }

    public class Realtime
    {
        public static void Run()
        {
            var mortgate = new Mortgage();
            mortgate.IsEligible(new Customer("Test"), 800);
        }
    }
}
