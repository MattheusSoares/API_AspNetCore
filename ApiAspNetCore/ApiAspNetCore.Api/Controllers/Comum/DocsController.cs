using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAspNetCore.Api.Controllers.Comum
{
    [RequireHttps]
    [Route("Docs")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DocsController : Controller
    {
        [Route(""), HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}