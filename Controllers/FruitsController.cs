using Microsoft.AspNetCore.Mvc;
using RestFulApiApp.Data;
using RestFulApiApp.Models;

namespace RestFulApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitsController : Controller
    {

        private readonly DataService _dataService;
        public FruitsController(DataService dataService)
        {
            _dataService = dataService;
        }

        // get all fruits  https://localhost:7273/fruits
        [HttpGet]
        public List<Fruit> GetFruits()
        {
            return _dataService.Fruits;
        }

        // get  fruit by id  https://localhost:7273/fruits/1
        [HttpGet("{id}")]
        public Fruit GetFruitById(int id)
        {
            var item = _dataService.Fruits.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }

            return item;
        }

        [HttpPost]
        public void CreateFruit(Fruit item)
        {
            _dataService.Fruits.Add(item);
        }

        // update fruit  https://localhost:7273/fruits
        [HttpPut]
        public void UpdateFruit(Fruit item)
        {
            var itemToReplace = _dataService.Fruits.FirstOrDefault(i => i.Id == item.Id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Fruits[item.Id] = item;
        }

        [HttpDelete("{id}")]
        public void DeleteFruit(int id)
        {
            var item = _dataService.Fruits.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Fruits.Remove(item);

        }
    }
}
