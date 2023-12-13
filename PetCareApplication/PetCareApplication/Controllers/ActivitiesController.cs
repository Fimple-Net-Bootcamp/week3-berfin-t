using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using PetCareApplication.Data;
using System.Diagnostics;

namespace PetCareApplication.Controllers
{
    [ApiController]
    [Route("api/v1/activities")]
    public class ActivitiesController : Controller
    {
        private readonly PetCareDbContext _petCareDbContext;

        public ActivitiesController(PetCareDbContext petCareDbContext)
        {
            _petCareDbContext = petCareDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Activities activity)
        {
            _petCareDbContext.Activities.Add(activity);
            await _petCareDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { petId = activity.Id }, activity);
        }

        [HttpGet("{petId}")]
        public IActionResult GetById(int petId)
        {
            var activity = _petCareDbContext.Activities.Where(x => x.Id == petId).FirstOrDefault();
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }
    }
}
