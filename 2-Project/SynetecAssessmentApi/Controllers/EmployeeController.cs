using Framework.Application;
using Framework.Application.Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Service.Contracts.Queries;
using SynetecAssessmentApi.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ICommandBus _commandBus;

        public EmployeeController(ICommandBus commandBus)
        {
            _commandBus = commandBus ?? throw new System.ArgumentNullException(nameof(commandBus));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await DispatchCommandAsync(new GetEmployeesQuery());
            return result;
        }
        [HttpPost("CalculateBonus")]
        public async Task<IActionResult> CalculateBonus([FromBody] GetEmplyeeBonusQuery command)
        {
            var result= await DispatchCommandAsync(command);
            return result;
        }
        private async Task<IActionResult> DispatchCommandAsync<T>(T command) where T:IRestrictedCommand
        {
            await _commandBus.DispatchAsync(command);
            IActionResult result = Ok();
            if (command.HaveResult())
            {
                var commandResult = command.GetResult();
                result = Ok(commandResult);
            }  
            return result;
        }
    }
}
