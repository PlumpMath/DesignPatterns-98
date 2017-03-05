using System.Data;

namespace BehavioralPatterns.TemplateMethod
{
    public abstract class DataAccessObject
    {
        protected string ConnectionString;
        protected DataSet DataSet;

        protected DataAccessObject()
        {
            DataSet = new DataSet();
        }

        public void Run()
        {
            Connect();
            Select();
            Process();
            Disconnect();
        }

        protected virtual void Connect()
        {
            ConnectionString = "";
        }

        protected virtual void Disconnect()
        {
            ConnectionString = string.Empty;
        }

        protected abstract void Select();

        protected abstract void Process();
    }

    public class Categories : DataAccessObject
    {
        protected override void Select()
        {
            var querySql = "select * from category where state = '1'";
            //TODO: Execute querySql to select datas, then fill the DataSet.
        }

        protected override void Process()
        {
            //foreach (var data in DataSet.Tables)
            //{
            //    //TODO: process each category item.
            //    Console.WriteLine(data);
            //}
        }
    }

    public class Products : DataAccessObject
    {
        protected override void Select()
        {
            var querySql = "select * from products where state = '1'";
        }

        protected override void Process()
        {
            //foreach (var product in DataSet)
            //{
            //    Console.WriteLine(product);
            //}
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var products = new Products();
            products.Run();
        }
    }
}
