using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using AppManager.Processors;
using AppManager.AppInterfaces;

namespace First.Net.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenProcessor itokenprocessor;
        public AuthController(ITokenProcessor itokenprocessor)
        {
            this.itokenprocessor = itokenprocessor;
        }
        public IActionResult Post()
        {
            return Ok(itokenprocessor.createNewWebToken());
        }
    }
}