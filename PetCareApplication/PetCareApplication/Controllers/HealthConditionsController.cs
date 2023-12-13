using Microsoft.AspNetCore.Mvc;
using PetCareApplication.Data;

namespace PetCareApplication.Controllers
{
    [ApiController]
    [Route("api/v1/healthConditions")]
    public class HealthConditionsController : Controller
    {
        private readonly PetCareDbContext _petCareDbContext;

        public HealthConditionsController(PetCareDbContext petCareDbContext)
        {
            _petCareDbContext = petCareDbContext;
        }

        [HttpGet("{petId}")]
        public IActionResult GetById(int petId)
        {
            var healthCondition = _petCareDbContext.HealthCondition.Where(x => x.Id == petId).FirstOrDefault();
            if (healthCondition == null)
            {                
                return NotFound();
            }
            return Ok(healthCondition);
        }

        [HttpPatch("{petId}")]
        public IActionResult Update(int petId, [FromBody] HealthCondition updatedHealthCondition)
        {
            var existingHealthCondition = _petCareDbContext.HealthCondition.FirstOrDefault(x => x.Id == petId);

            if (existingHealthCondition == null)
            {
                return NotFound();
            }

            _petCareDbContext.SaveChanges();

            return Ok(existingHealthCondition);
        }

    }
}
