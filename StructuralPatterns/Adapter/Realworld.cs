using System;

namespace StructuralPatterns.Adapter
{
    public class Compound
    {
        
    }

    public class Client
    {
        public virtual void Paint()
        {
            
        }
    }

    public class WpfClient : Client
    {
        private readonly IWinformControl _winformControl;

        public WpfClient(IWinformControl winformControl)
        {
            _winformControl = winformControl;
        }

        public override void Paint()
        {
            PaintSelf();
            _winformControl.Paint();
        }

        private void PaintSelf()
        {
            Console.WriteLine("Wpf control.");
        }
    }

    public interface IWinformControl
    {
        void Paint();
    }

    public class WinformControl:IWinformControl
    {
        public void Paint()
        {
            Console.WriteLine("Winform control paint.");
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var client = new WpfClient(new WinformControl());
            client.Paint();
        }
    }
}
