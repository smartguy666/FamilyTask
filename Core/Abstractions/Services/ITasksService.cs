using Domain.Commands;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstractions.Services
{
    public interface ITasksService
    {
        Task<CreateMemberTasksCommandResult> CreateMemberTaskCommandHandler(CreateMemberTaskCommand command);
        Task<GetAllMemberTasksQueryResult> GetAllMemberTasksQueryHandler();
        Task<GetDeleteMemberQueryResults> DeleteTaskQueryHandler(Guid ID);
    }
   
}
