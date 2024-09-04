using MediatR;
using Microsoft.EntityFrameworkCore;
using MSY.Database;
using MSY.Database.Models;
using MSY.Infrastructure.Commands.ModulesData;
using MSY.Infrastructure.Exceptions;

namespace MSY.Infrastructure.Handlers.ModulesData;

public class GetLastPayloadHandler(DbMSYContext context)
    : IRequestHandler<GetLastPayloadCommand, ModuleData>
{
    
    public async Task<ModuleData> Handle(GetLastPayloadCommand request, CancellationToken cancellationToken)
    {
        var data = await context.ModulesData
            .Where(md => md.ObjectId == request.ObjectId)
            .OrderByDescending(md => md.CreatedAt)
            .FirstOrDefaultAsync(cancellationToken);
        if (data is null)
            throw new MsyServiceException("Не удалось получить данные");
        return data;
    }
}