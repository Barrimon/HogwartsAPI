using HogwartsCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseApiController<TController> : ControllerBase
    {
        protected readonly IAppLogger<TController> logger;

        public BaseApiController(IAppLogger<TController> logger)
        {
            this.logger = logger;
        }
    }
}
