using RestFulApiApp.Models;

namespace RestFulApiApp.Data
{
    public class DataService
    {
        public List<Fruit> Fruits { get; set; }

        public DataService()
        {
            Fruits = new List<Fruit>();
        }
    }
}
