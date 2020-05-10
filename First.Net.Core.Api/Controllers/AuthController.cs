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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using AppModels.ConfigModels;

namespace First.Net.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenProcessor itokenprocessor;
        private JWTConfiguration jwtConfiguration;
        public AuthController(ITokenProcessor itokenprocessor, IOptions<JWTConfiguration> jwtConfiguration)
        {
            this.itokenprocessor = itokenprocessor;
            this.jwtConfiguration = jwtConfiguration.Value;
        }
        public IActionResult Post()
        {
            return Ok(itokenprocessor.createNewWebToken(jwtConfiguration));
        }
    }
}