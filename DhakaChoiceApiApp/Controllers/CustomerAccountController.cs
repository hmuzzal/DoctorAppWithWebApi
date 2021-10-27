using System.Threading.Tasks;
using DhakaChoiceApiApp.Data;
using DhakaChoiceApiApp.DTOs;
using DhakaChoiceApiApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DhakaChoiceApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerAccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser()
            {
                PhoneNumber = userDto.PhoneNumber,
                UserName = userDto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
                return BadRequest(result);

            await _userManager.AddToRoleAsync(user, "Customer");
            return Ok();
        }

    }
}
