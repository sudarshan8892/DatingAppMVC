using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDatingAPP.DATA;
using WebAPIDatingAPP.Entities;

namespace WebAPIDatingAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUsersController : BaseApiController
    {

        private readonly DataContext _context;

        public AppUsersController(DataContext dataContext)
        {
            _context = dataContext;
        }
        [HttpGet]
        //api/AppUsers
        public async Task<ActionResult<IEnumerable<AppUsers>>>GetUsers()
        {
            var users = await _context.AppUsers.ToListAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        //api/AppUsers/1
        public async Task<ActionResult<AppUsers>> GetUserbyId(int id)
        {
            var users = await _context.AppUsers.FindAsync(id);
            return Ok(users);
        }

    }
}
