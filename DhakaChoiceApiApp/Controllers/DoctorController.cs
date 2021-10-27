using System.Linq;
using System.Threading.Tasks;
using DhakaChoiceApiApp.Data;
using DhakaChoiceApiApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DhakaChoiceApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            return Ok(await _userManager.GetUsersInRoleAsync("Doctor"));
        }

        public class UserInRole
        { 
            public string UserId { get; set; }  
            public string Username { get; set; }  
            public string Email { get; set; }  
            public string Role { get; set; }  
            
        }

        [HttpGet]
        [Route("HospitalWiseDoctors")]
        public async Task<IActionResult> HospitalWiseDoctorList()
        {
            var users = (from user in (await _userManager.GetUsersInRoleAsync("Doctor"))
                select new
                {
                    user,
                    RoleName = (from userRole in _context.UserRoles where userRole.UserId == user.Id
                        join role in _context.Roles on userRole.RoleId equals role.Id select role.Name).ToList()
                }).ToList();
            return Ok(users);
        }
    }
}

