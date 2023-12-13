using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Data;

namespace PetCareApplication.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private readonly PetCareDbContext _petCareDbContext;

        public UsersController(PetCareDbContext petCareDbContext)
        {
            _petCareDbContext = petCareDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _petCareDbContext.User.Add(user);
            await _petCareDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { userId = user.Id }, user);
        }

        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            var user = _petCareDbContext.User.Where(x => x.Id == userId).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
