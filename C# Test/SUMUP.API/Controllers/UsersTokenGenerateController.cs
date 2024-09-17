using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SUMUP.API.Models;
using Microsoft.Extensions.Configuration;
using SUMUP.API.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace SUMUP.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersTokenGenerateController : Controller
    {
        private readonly ISamulp_DQC342Repository _samulpDQC342Repository;

        //private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UsersTokenGenerateController(ISamulp_DQC342Repository Samulp_DQC342Repository, IConfiguration configuration)
        {
            _samulpDQC342Repository = Samulp_DQC342Repository;
            _configuration = configuration;
        }


        /// <summary>
        /// Generate token acess to users. To get access to another API´s in this project.
        /// </summary>        
        /// <returns>A string value</returns>        
        /// <response code="204">Data Not Found for the especifications.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="404">Error - Data Error!</response>
        /// <response code="500">Exception Ocorr to receive data. Internal server error".</response>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult>  GenerateTokenAccess([FromBody] Users loginDetails)
        {
            var user = await _samulpDQC342Repository.GetLogin(loginDetails.Username,loginDetails.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var tokenString = GerarTokenJwt();
                        
            return Ok(new { token = tokenString });
                        
        }

        [NonAction]
        public string GerarTokenJwt()
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expiry = DateTime.Now.AddHours(1);
            
            var securityKey = new SymmetricSecurityKey
                              (Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             expires: DateTime.Now.AddHours(1),
                                             signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

    }
}
