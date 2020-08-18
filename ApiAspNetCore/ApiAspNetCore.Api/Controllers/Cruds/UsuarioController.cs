using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiAspNetCore.Api.Controllers.Cruds
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("v1/Usuarios")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}