using Microsoft.AspNetCore.Mvc;
using RestFulApiApp.Data;
using RestFulApiApp.Models;

namespace RestFulApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishesController : Controller
    {
        private readonly DataContext _dataContext;

        public DishesController(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentException(nameof(_dataContext));
        }

       
        [HttpGet]
        public IActionResult GetDishes()
        {
            var result = _dataContext.Dishes.ToList();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // get by id https://localhost:7273/dishes/1
        [HttpGet("{id}")]
        public Dish GetDishById(int id)
        {
            var itemById = _dataContext.Dishes.FirstOrDefault(d => d.Id == id);
            
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
            _dataContext.Dishes.Add(item);
            _dataContext.SaveChanges();
        }

        // update https://localhost:7273/dishes
        [HttpPut]
        public void UpdateDish(Dish item)
        {
           
            _dataContext.Dishes.Update(item);
            _dataContext.SaveChanges();


        }

        // delete by id https://localhost:7273/dishes/1
        [HttpDelete("{id}")]
        public void DeleteDish(int id)
        {
            var dishToDelete = _dataContext.Dishes.FirstOrDefault(d => d.Id == id);

            if (dishToDelete == null)
            {
                throw new KeyNotFoundException();
            }

            _dataContext.Remove(dishToDelete);
            _dataContext.SaveChanges();
        }
    }
}
