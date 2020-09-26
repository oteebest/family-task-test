using Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Abstractions.Repositories
{
    public interface ITaskRepository : IBaseRepository<Guid, Task, ITaskRepository>
    {
        System.Threading.Tasks.Task<Task> GetByTaskId(Guid taskId);
    }
}
