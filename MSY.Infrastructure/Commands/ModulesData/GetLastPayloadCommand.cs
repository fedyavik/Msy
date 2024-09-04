using System.ComponentModel.DataAnnotations;
using MediatR;
using MSY.Database.Models;

namespace MSY.Infrastructure.Commands.ModulesData
{
    public class GetLastPayloadCommand: IRequest<ModuleData>
    {
        /// <summary>
        /// Номер объекта
        /// </summary>
        [Required]
        public long ObjectId { get; set; }
    }
}