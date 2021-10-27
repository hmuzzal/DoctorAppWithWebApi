using System.Linq;
using System.Threading.Tasks;
using DhakaChoiceApiApp.Data;
using DhakaChoiceApiApp.DTOs;
using DhakaChoiceApiApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DhakaChoiceApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;


        public DoctorAccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto model)
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



        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public string Login([FromBody] LoginUserDto user)
        {
            if (!ModelState.IsValid) return JsonConvert.SerializeObject("Invalid login attempt.");
            var authorizeUser =  _userManager.Users.FirstOrDefault(x => x.UserName == user.UserName);

            if (authorizeUser == null)
            {
                return JsonConvert.SerializeObject("No user found with this email");
            }

            var result = _signInManager.PasswordSignInAsync(authorizeUser, user.Password, user.RememberMe, lockoutOnFailure: false).GetAwaiter().GetResult();


            if (!result.Succeeded) return JsonConvert.SerializeObject("Invalid login attempt.");
            var roles =  _userManager.GetRolesAsync(authorizeUser).GetAwaiter().GetResult();
            if (roles.Any())
            {
                return JsonConvert.SerializeObject(authorizeUser +", "+ roles.FirstOrDefault());
            }
            return JsonConvert.SerializeObject("Invalid login attempt.");
        }
    }
}
