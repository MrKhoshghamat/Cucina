using Cucina.API.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Cucina.API.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}