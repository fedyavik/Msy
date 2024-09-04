using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSY.Database.Models;
using MSY.Infrastructure.Commands.ModulesData;

namespace MSY.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleDataController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Получение статуса объекта
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<GetObjectStatusCommandResponse> Get(
        [FromBody] GetObjectStatusCommand command,
        CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result;
    }
    /// <summary>
    /// Получение данных последнего пакета с объекта
    /// </summary>
    /// <returns></returns>
    [HttpPost("LastPayload")]
    public async Task<ModuleData> GetPayload(
        [FromBody] GetLastPayloadCommand command,
        CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result;
    }
}