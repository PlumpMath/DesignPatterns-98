using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Decorator
{
    public interface IWindow
    {
        void Draw();
        string GetDescription();
    }

    public class SimpleWindow : IWindow
    {
        public void Draw()
        {
            Console.WriteLine("Simple window");
        }

        public string GetDescription()
        {
            return "Simple window";
        }
    }

    public abstract class WindowDecorator : IWindow
    {
        private readonly IWindow _window;

        protected WindowDecorator(IWindow window)
        {
            _window = window;
        }

        public virtual void Draw()
        {
            _window.Draw();
        }

        public virtual string GetDescription()
        {
            return _window.GetDescription();
        }
    }

    public class HorizationalBarWindowDecorator : WindowDecorator
    {
        public HorizationalBarWindowDecorator(IWindow window):base(window)
	    {

        }

        public override void Draw()
        {
            AddHorizationalBar();
            base.Draw();
        }

        public override string GetDescription()
        {
            return string.Concat(base.GetDescription(), " with horizational bar.");
        }

        private void AddHorizationalBar()
        {
            Console.WriteLine("draw horizational bar.");
        }
    }

    public class VerticalBarWindowDecorator : WindowDecorator
    {
        public VerticalBarWindowDecorator(IWindow window) : base(window)
        {

        }

        public override void Draw()
        {
            base.Draw();
            AddVerticalBar();
        }

        public override string GetDescription()
        {
            return string.Concat(base.GetDescription(), " with vertical bar.");
        }

        private void AddVerticalBar()
        {
            Console.WriteLine("draw vertical bar.");
        }
    }
    public class Realword1
    {
        public static void Run()
        {
            var window = new SimpleWindow();
            var horizationalBarWindow = new HorizationalBarWindowDecorator(window);
            var verticalBarWindow = new VerticalBarWindowDecorator(horizationalBarWindow);
            verticalBarWindow.Draw();
        }
    }
}
