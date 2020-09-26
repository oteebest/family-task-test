using Core.Abstractions.Repositories;
using Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class TaskRepository : BaseRepository<Guid, Task, TaskRepository>, ITaskRepository
    {
        public TaskRepository(FamilyTaskContext context) : base(context)
        { }

        public async System.Threading.Tasks.Task<Task> GetByTaskId(Guid taskId)
        {
           return  await Context.Set<Task>().FirstAsync(u => u.TaskId == taskId);
        }

        ITaskRepository IBaseRepository<Guid, Task, ITaskRepository>.NoTrack()
        {
            return base.NoTrack(); ;
        }

        ITaskRepository IBaseRepository<Guid, Task, ITaskRepository>.Reset()
        {
            return base.NoTrack();
        }
    }
}
