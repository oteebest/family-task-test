using Domain.Commands;
using Domain.Queries;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstractions.Services
{
    public interface ITaskService
    {
        Task<CreateTaskCommandResult> CreateTaskForMemberCommandHandler(CreateTaskCommand command);
        Task<AssignTaskCommandResult> AssignTaskToMember(Guid taskId,Guid memberId);
        Task<ToggleTaskActiveStatusResult> ToggleActiveStatus(Guid id);
        Task<GetAllTaskQueryResult> GetAllTask();
        Task<GetAllTaskQueryResult> GetMemberTasks(Guid memberId);
        Task<CreateTaskCommandResult> CreateNewTaskCommandHandler(CreateTaskCommand command);


    }
}
