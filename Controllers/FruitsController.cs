using Microsoft.AspNetCore.Mvc;
using RestFulApiApp.Data;
using RestFulApiApp.Models;

namespace RestFulApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitsController : Controller
    {

        private readonly DataContext _dataContext;

        public FruitsController(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentException(nameof(_dataContext));
        }

        // get all fruits  https://localhost:7273/fruits
        [HttpGet]
        public List<Fruit> GetFruits()
        {
            return _dataContext.Fruits.ToList();
        }

        // get  fruit by id  https://localhost:7273/fruits/1
        [HttpGet("{id}")]
        public Fruit GetFruitById(int id)
        {
            var item = _dataContext.Fruits.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }

            return item;
        }

        [HttpPost]
        public void CreateFruit(Fruit item)
        {
            _dataContext.Add(item);
            _dataContext.SaveChanges();
        }

        // update fruit  https://localhost:7273/fruits
        [HttpPut]
        public void UpdateFruit(Fruit item)
        {
            _dataContext.Fruits.Update(item);
            _dataContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteFruit(int id)
        {
            var item = _dataContext.Fruits.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _dataContext.Remove(item);
                _dataContext.SaveChanges();
            }
        }
    }
}
