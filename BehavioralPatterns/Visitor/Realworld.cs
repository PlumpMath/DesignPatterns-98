using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Visitor
{
    public interface IEmployeeVisitor
    {
        void Visit(IEmployee employee);
    }

    public class SalaryVisitor : IEmployeeVisitor
    {
        private const double PromotePercentage = 0.1;

        public void Visit(IEmployee employee)
        {
            employee.PromoteSalary(PromotePercentage);
            employee.Display();
        }
    }

    public class VacationDaysVisitor : IEmployeeVisitor
    {
        private const int PromoteVacationDays = 5;

        public void Visit(IEmployee employee)
        {
            employee.PromoteVacationDays(PromoteVacationDays);
            employee.Display();
        }
    }

    public interface IProbationer
    {
        
    }

    public interface IEmployee : IProbationer
    {
        void Accept(IEmployeeVisitor visitor);

        void PromoteSalary(double percent);

        void PromoteVacationDays(int days);

        void Display();
    }

    public abstract class Employee : IEmployee
    {
        public double Salary { get; set; }

        public int VacationDays { get; set; }

        public void Accept(IEmployeeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public virtual void PromoteSalary(double percent)
        {
            Salary += Salary*percent;
        }

        public virtual void PromoteVacationDays(int days)
        {
            VacationDays += days;
        }

        public void Display()
        {
            Console.WriteLine($"Salery {Salary}, VacationDays:{VacationDays}");
        }
    }

    public class Probationer : IProbationer
    {
        
    }

    public class Clerk : Employee
    {

    }

    public class Director : Employee
    {
        
    }

    public class President : Employee
    {
        
    }

    public class DataStructure
    {
        private readonly IList<IProbationer> _persons = new List<IProbationer>();

        public void Add(IProbationer probationer)
        {
            _persons.Add(probationer);
        }

        public void Visit(IEmployeeVisitor visitor)
        {
            foreach (var probationer in _persons)
            {
                var employee = probationer as IEmployee;
                if (employee != null)
                {
                    visitor.Visit(employee);
                }
            }
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var dataStructure = new DataStructure();
            dataStructure.Add(new Probationer());
            dataStructure.Add(new Clerk {Salary = 1000, VacationDays = 5});
            dataStructure.Add(new Director { Salary = 10000, VacationDays = 10 });
            dataStructure.Add(new President { Salary = 100000, VacationDays = 30 });
            dataStructure.Visit(new SalaryVisitor());
            dataStructure.Visit(new VacationDaysVisitor());
        }
    }
}
