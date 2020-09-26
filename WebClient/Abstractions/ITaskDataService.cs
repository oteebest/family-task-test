using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Abstractions
{
    public interface ITaskDataService
    {

        Task AssignTaskToMember(string taskId, string memberId);

        public Task<TaskModel[]> GetAllTask();

        public Task<TaskModel[]> GetMemberTask(Guid memberId);

        public Task<TaskModel> CreateTask(NewTask task);

        Task ToggleActiveStatus(Guid id);

    }
}
