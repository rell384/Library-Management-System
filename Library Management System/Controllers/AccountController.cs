using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Library_Management_System.Models;
using Library_Management_System.Repository;
using System.Text;
using Library_Management_System.DTO;
namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController
            (UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }
        //api/account/register :post
        [HttpPost("register")]
        public async Task<IActionResult> Register(RigesterUserDTO userDto)//(un,ps,email)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appuser = new ApplicationUser()
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    PasswordHash = userDto.Password
                };
                //create account in db
                IdentityResult result =
                    await userManager.CreateAsync(appuser, userDto.Password);
                if (result.Succeeded)
                {
                    //create token (optional)
                    return Ok("Account Created");
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]//api/account/login (username /passwor)
        public async Task<IActionResult> Login(LoginUserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? userFromDb =
                     await userManager.FindByNameAsync(userDto.UserName);
                if (userFromDb != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userFromDb, userDto.Password);
                    if (found)
                    {
                        //bl :the same user with each login  take different token
                        List<Claim> myclaims = new List<Claim>();
                        myclaims.Add(new Claim(ClaimTypes.Name, userFromDb.UserName));
                        myclaims.Add(new Claim(ClaimTypes.NameIdentifier, userFromDb.Id));
                        myclaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        //claim  roles
                        var roles = await userManager.GetRolesAsync(userFromDb);
                        foreach (var role in roles)
                        {
                            myclaims.Add(new Claim(ClaimTypes.Role, role));
                        }


                        var SignKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["JWT:SecritKey"]));//"fdfgdfdfgdgfd

                        SigningCredentials signingCredentials =
                            new SigningCredentials(SignKey, SecurityAlgorithms.HmacSha256);



                        //create token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            issuer: config["JWT:ValidIss"],//provider create token
                            audience: config["JWT:ValidAud"],//cousumer url
                            expires: DateTime.Now.AddHours(1),
                            claims: myclaims,
                            signingCredentials: signingCredentials);
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                            expired = mytoken.ValidTo
                        });
                    }
                }
                return Unauthorized("Invalid account");
            }
            return BadRequest(ModelState);
        }
    }
}
