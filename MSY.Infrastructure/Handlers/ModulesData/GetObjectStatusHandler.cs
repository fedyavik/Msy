using MediatR;
using Microsoft.EntityFrameworkCore;
using MSY.Database;
using MSY.Infrastructure.Commands.ModulesData;

namespace MSY.Infrastructure.Handlers.ModulesData;

public class GetObjectStatusHandler(DbMSYContext context)
    : IRequestHandler<GetObjectStatusCommand, GetObjectStatusCommandResponse>
{
    
    public async Task<GetObjectStatusCommandResponse> Handle(GetObjectStatusCommand request, CancellationToken cancellationToken)
    {
        var dataCount = await context.ModulesData
            .Where(md => md.ObjectId == request.ObjectId && 
                         md.CreatedAt > (DateTime.UtcNow - TimeSpan.FromHours(1)))
            .OrderByDescending(md => md.Id)
            .Take(1)
            .CountAsync(cancellationToken);
        return new GetObjectStatusCommandResponse()
        {
            IsWorking = dataCount > 0
        };
    }
}