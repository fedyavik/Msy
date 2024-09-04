using System.ComponentModel.DataAnnotations;
using MediatR;

namespace MSY.Infrastructure.Commands.ModulesData
{
    public class GetObjectStatusCommand: IRequest<GetObjectStatusCommandResponse>
    {
        /// <summary>
        /// Номер объекта
        /// </summary>
        [Required]
        public long ObjectId { get; set; }
    }
    public class GetObjectStatusCommandResponse
    {
        /// <summary>
        /// Статус объекта
        /// True - означает что объект работает исправно
        /// False - объект сломан
        /// </summary>
        public bool IsWorking { get; set; }
    }
}