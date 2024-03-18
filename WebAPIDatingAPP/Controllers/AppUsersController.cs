using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDatingAPP.DATA;
using WebAPIDatingAPP.Entities;

namespace WebAPIDatingAPP.Controllers
{
    [ApiController]
    [Route("[Api/controller]")]
    public class AppUsersController : ControllerBase
    {

        private readonly DataContext _context;

        public AppUsersController(DataContext dataContext)
        {
            _context = dataContext;
        }
        [HttpGet]
        //AppUsers/GetUsers
        public async Task<ActionResult<IEnumerable<AppUsers>>> GetUsers()
        {
            var users = await _context.AppUsers.ToListAsync();
            return users;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUsers>> GetUser(int id)
        {
            var users = await _context.AppUsers.FindAsync(id);
            return users;
        }

    }
}
