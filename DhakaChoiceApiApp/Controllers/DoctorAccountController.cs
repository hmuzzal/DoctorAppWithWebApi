using System.Threading.Tasks;
using DhakaChoiceApiApp.Models;
using DhakaChoiceApiApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DhakaChoiceApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorAccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser { UserName = model.PhoneNumber, PhoneNumber = model.PhoneNumber };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            await _userManager.AddToRoleAsync(user, "Doctor");
               
            return Ok();
        }

    }
}
