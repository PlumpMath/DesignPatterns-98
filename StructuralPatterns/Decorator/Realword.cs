using System;

namespace StructuralPatterns.Decorator
{
    public abstract class LibraryItem
    {
        public virtual void Operation()
        {
            
        }
    }

    public class Book : LibraryItem
    {
        public override void Operation()
        {
            Console.WriteLine("Handle book.");
        }
    }

    public class Video : LibraryItem
    {
        public override void Operation()
        {
            Console.WriteLine("Handle video.");
        }
    }

    public abstract class LibraryItemDecorator : LibraryItem
    {
        protected LibraryItemDecorator(LibraryItem libraryItem)
        {
            Component = libraryItem;
        }

        public LibraryItem Component { get; set; }
    }

    public class BorrowableDecorator : LibraryItemDecorator
    {
        public BorrowableDecorator(LibraryItem libraryItem) 
            : base(libraryItem)
        {

        }

        public override void Operation()
        {
            base.Operation();
            AddBorrowableBehavior();
        }

        private void AddBorrowableBehavior()
        {
            Console.WriteLine("This item has borrowable behavior.");
        }
    }

    public class Realword
    {
        public static void Run()
        {
            var item = new Book();
            var decorator = new BorrowableDecorator(item);
            decorator.Operation();
        }
    }
}
