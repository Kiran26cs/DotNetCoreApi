using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace First.Net.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IActionResult GetToken()
        {
            //the secret Key
            string secretKey = "Hello_secret_key";
            //Create symetric key 
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            //sign the token
            var signingCredentails = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            //Create the token

            var token = new JwtSecurityToken(issuer:"KiransComputer", audience: "someReceiver", expires:DateTime.Now.AddMinutes(1), signingCredentials: signingCredentails);
            
            
            //write the token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}