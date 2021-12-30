using Microsoft.AspNetCore.Mvc;
using RestFulApiApp.Data;
using RestFulApiApp.Models;

namespace RestFulApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VegetablesController : Controller
    {
        private readonly DataService _dataService;

        public VegetablesController(DataService dataService)
        {
            _dataService = dataService;
        }

        // get all https://localhost:7273/veetables
        [HttpGet]
        public List<Vegetable> GetVegetables()
        {
            return _dataService.Vegetables;
        }

        // get by id  https://localhost:7273/vegetables/1
        [HttpGet("{id}")]
        public Vegetable GetVegetableById(int id)
        {
            var item = _dataService.Vegetables.FirstOrDefault( v => v.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            return item;
        }

        [HttpPost]
        public void CreateVegetable(Vegetable item)
        {
            
            _dataService.Vegetables.Add(item);
        }

        [HttpPut]
        public void UpdateVegetable(Vegetable item)
        {
            var itemToReplace = _dataService.Vegetables.FirstOrDefault(v => v.Id == item.Id);
            if (itemToReplace == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Vegetables[item.Id] = item;
        }

        [HttpDelete("{id}")]
        public void DeleteVegetable(int id)
        {
            var itemToDelete = _dataService.Vegetables.FirstOrDefault(v => v.Id == id);
            if (itemToDelete == null)
            {
                throw new KeyNotFoundException(); 
            }

            _dataService.Vegetables.Remove(itemToDelete);
        }
    }
}
