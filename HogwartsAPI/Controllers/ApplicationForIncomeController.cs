using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsCore.Services;
using HogwartsCore.Services.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsAPI.Controllers
{
    public class ApplicationForIncomeController : BaseApiController<ApplicationForIncomeController>
    {
        private readonly IApplicationForIncomeService applicationForIncomeService;

        public ApplicationForIncomeController(IAppLogger<ApplicationForIncomeController> logger,
                                            IApplicationForIncomeService applicationForIncomeService) : base(logger)
        {
            this.applicationForIncomeService = applicationForIncomeService;
        }

        [HttpPost]
        public async Task<IActionResult> Crate([FromBody] ApplicationForIncomeModel model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            logger.LogInformation(nameof(Crate), model);
            return Ok(await applicationForIncomeService.Create(model));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ApplicationForIncomeModel model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            logger.LogInformation(nameof(Update), model);
            return Ok(await applicationForIncomeService.Update(model));
        }

        [HttpDelete("{EntityCode}")]
        public async Task<IActionResult> Delete(string EntityCode)
        {
            if (Guid.TryParse(EntityCode, out Guid newGuid))
            {
                if (!ModelState.IsValid) { return BadRequest(ModelState); }
                logger.LogInformation(nameof(Delete), EntityCode);
                return Ok(await applicationForIncomeService.Delete(newGuid));
            }
            else
            {
                return BadRequest("It is not a valid EntityCode");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            logger.LogInformation(nameof(GetAll));
            return Ok(await applicationForIncomeService.GetAll());
        }

        [HttpGet("{EntityCode}")]
        public async Task<IActionResult> GetByCode(string EntityCode)
        {
            if (Guid.TryParse(EntityCode, out Guid newGuid))
            {
                logger.LogInformation(nameof(GetByCode));
                return Ok(await applicationForIncomeService.GetByCode(newGuid));
            }
            else
            {
                return BadRequest("It is not a valid EntityCode");
            }
        }
    }
}