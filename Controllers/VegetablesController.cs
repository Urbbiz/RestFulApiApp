using Microsoft.AspNetCore.Mvc;
using RestFulApiApp.Data;
using RestFulApiApp.Models;

namespace RestFulApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetablesController : Controller
    {
        private readonly DataContext _dataContext;

        public VegetablesController(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentException(nameof(_dataContext));
        }

        // get all https://localhost:7273/veetables
        [HttpGet]
        public List<Vegetable> GetVegetables()
        {
            return _dataContext.Vegetables.ToList();
        }

        // get by id  https://localhost:7273/vegetables/1
        [HttpGet("{id}")]
        public Vegetable GetVegetableById(int id)
        {
            var item = _dataContext.Vegetables.FirstOrDefault( v => v.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            return item;
        }

        [HttpPost]
        public void CreateVegetable(Vegetable item)
        {

            _dataContext.Add(item);
            _dataContext.SaveChanges();
        }

        [HttpPut]
        public void UpdateVegetable(Vegetable item)
        {
                _dataContext.Vegetables.Update(item);
                _dataContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteVegetable(int id)
        {
            var itemToDelete = _dataContext.Vegetables.FirstOrDefault(v => v.Id == id);
            if (itemToDelete != null)
            {
                _dataContext.Remove(itemToDelete);
                _dataContext.SaveChanges();
            }

        }
    }
}
