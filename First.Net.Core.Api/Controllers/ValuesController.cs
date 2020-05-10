using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace First.Net.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Authorize(Roles = "SchemeOperator")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return  Ok("JWT token based simple project");
        }

        [HttpGet]
        [Route("CommonEndpoint")]
        public ActionResult<IEnumerable<string>> CommonEndpoint()
        {
            return Ok("This could be accessed by any roles");
        }

    }
}
