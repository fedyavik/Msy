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
    [HttpGet]
    public async Task<GetObjectStatusCommandResponse> Get(
        [FromQuery] GetObjectStatusCommand command,
        CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result;
    }
    /// <summary>
    /// Получение данных последнего пакета с объекта
    /// </summary>
    /// <returns></returns>
    [HttpGet("LastPayload")]
    public async Task<ModuleData> GetPayload(
        [FromQuery] GetLastPayloadCommand command,
        CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return result;
    }
}