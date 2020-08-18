using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ApiAspNetCore.Api.Controllers.Comum
{
    [RequireHttps]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public object Home()
        {
            return "Versão do Assembly da WebApi ==> " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}