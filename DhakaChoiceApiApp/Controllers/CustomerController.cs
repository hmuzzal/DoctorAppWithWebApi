using System.Linq;
using System.Threading.Tasks;
using DhakaChoiceApiApp.Data;
using DhakaChoiceApiApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DhakaChoiceApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
           return Ok(await _userManager.GetUsersInRoleAsync("Customer"));
        }
    }
}
