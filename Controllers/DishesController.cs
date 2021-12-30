using Microsoft.AspNetCore.Mvc;
using RestFulApiApp.Data;
using RestFulApiApp.Models;

namespace RestFulApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishesController : Controller
    {
        private readonly DataService _dataService;

        public DishesController(DataService dataService)
        {
            _dataService = dataService;
        }

        // get all  https://localhost:7273/dishes
        [HttpGet]
        public List<Dish> GetDishes()
        {
            return _dataService.Dishes;
        }


        // get by id https://localhost:7273/dishes/1
        [HttpGet("{id}")]
        public Dish GetDishById(int id)
        {
            var itemById = _dataService.Dishes.FirstOrDefault(d => d.Id == id);
            
            if(itemById == null)
            {
                throw new KeyNotFoundException();
            }
            return itemById;
        }

        [HttpPost]
        // create https://localhost:7273/dishes
        public void CreateDish(Dish item)
        {
            _dataService.Dishes.Add(item);
        }

        // update https://localhost:7273/dishes
        [HttpPut]
        public void UpdateDish(Dish item)
        {
            var dishToUpdate = _dataService.Dishes.FirstOrDefault(d => d.Id == item.Id);
                
                if (dishToUpdate == null)
            {
                throw new KeyNotFoundException();
            }
               
            _dataService.Dishes[item.Id] = item;

        }

        // delete by id https://localhost:7273/dishes/1
        [HttpDelete("{id}")]
        public void DeleteDish(int id)
        {
            var dishToDelete = _dataService.Dishes.FirstOrDefault(d => d.Id == id);

            if (dishToDelete == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Dishes.Remove(dishToDelete);
        }
    }
}
