using System;
using System.Collections.Generic;
using System.Linq;

namespace CreationalPatterns.Singleton
{
    public class Server
    {
        public Server()
        {
            Key = Guid.NewGuid().ToString();
        }

        public string Key { get; set; }    
    }

    internal sealed class LoadBalancer
    {
        private static readonly object LockThis = new object();
        private static LoadBalancer _instance;
        private readonly IList<Server> _servers = new List<Server>();

        private LoadBalancer()
        {
            _servers.Add(new Server());
            _servers.Add(new Server());
            _servers.Add(new Server());
            _servers.Add(new Server());
        }

        public static LoadBalancer GetInstance()
        {
            if (_instance == null)
            {
                lock (LockThis)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }

            return _instance;
        }

        public void FetchNextServer()
        {
            var serverIndex = new Random().Next(_servers.Count);
            var server = _servers[serverIndex];
            Console.WriteLine(server.Key);
        }
    }

    public class Realtime
    {
        public static void Run()
        {
            var loadBalancer = LoadBalancer.GetInstance();
            Enumerable.Range(0, 10).ToList().ForEach(x=>loadBalancer.FetchNextServer());
        }
    }
}
