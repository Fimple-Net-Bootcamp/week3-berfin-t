using Microsoft.AspNetCore.Mvc;
using PetCareApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace PetCareApplication.Controllers
{
    [ApiController]
    [Route("api/v1/foods")]
    public class FoodsController : Controller
    {
        private readonly PetCareDbContext _petCareDbContext;

        public FoodsController(PetCareDbContext petCareDbContext)
        {
            _petCareDbContext = petCareDbContext;
        }

        [HttpGet("/foods")]
        public async Task<IActionResult> GetAll()
        {
            var food = await _petCareDbContext.Food.ToListAsync();

            return Ok(food);
        }

        [HttpGet("{petId}")]
        public IActionResult GetById(int petId)
        {
            var food = _petCareDbContext.Food.Where(x => x.Id == petId).FirstOrDefault();
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }
    }
}
