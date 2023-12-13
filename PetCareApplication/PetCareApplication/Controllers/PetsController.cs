using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Data;
using System.Reflection.PortableExecutable;

namespace PetCareApplication.Controllers
{
    [ApiController]
    [Route("api/v1/pets")]
    public class PetsController : Controller
    {
        private readonly PetCareDbContext _petCareDbContext;

        public PetsController(PetCareDbContext petCareDbContext)
        {
            _petCareDbContext = petCareDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Pet pet)
        {
            _petCareDbContext.Pet.Add(pet);
            await _petCareDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { petId = pet.Id }, pet);
        }

        [HttpGet("/pets")]
        public async Task<IActionResult> GetAll()
        {
            var pet = await _petCareDbContext.Pet.ToListAsync();

            return Ok(pet);
        }

        [HttpGet("{petId}")]
        public IActionResult GetById(int petId)
        {
            var pet = _petCareDbContext.Pet.Where(x => x.Id == petId).FirstOrDefault();
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        [HttpPut("{petId}")]
        public async Task<IActionResult> Update(int petId, Pet pet)
        {

            var current = _petCareDbContext.Pet.Where(x => x.Id == petId).FirstOrDefault();

            if (current is null)
            {
                return NotFound();
            }

            current.PetName = pet.PetName;
            current.Kind = pet.Kind;
            current.Age = pet.Age;
            current.Gender = pet.Gender;


            await _petCareDbContext.SaveChangesAsync();

            return Ok();

        }

    }
}
