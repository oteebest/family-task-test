using AutoMapper;
using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Domain.Commands;
using Domain.Queries;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public TaskService(IMapper mapper, ITaskRepository taskRepository,
            IMemberRepository memberRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _memberRepository = memberRepository;
        }

        public async Task<AssignTaskCommandResult> AssignTaskToMember(Guid taskId, Guid memberId)
        {
            var isSucceed = true;
            var task = await _taskRepository.GetByTaskId(taskId);
            var member = await _memberRepository.GetByMemberId(memberId);

            task.AssignedMemberId = member.Id;

            var affectedRecordsCount = await _taskRepository.UpdateRecordAsync(task);

            if (affectedRecordsCount < 1)
                isSucceed = false;

            return new AssignTaskCommandResult()
            {
                Succeed = isSucceed
            };
        }

        public async Task<ToggleTaskActiveStatusResult> ToggleActiveStatus(Guid id)
        {
            var isSucceed = true;
            var task = await _taskRepository.GetByTaskId(id);

            task.IsComplete = !task.IsComplete;

            var affectedRecordsCount = await _taskRepository.UpdateRecordAsync(task);

            if (affectedRecordsCount < 1)
                isSucceed = false;
            
            return new ToggleTaskActiveStatusResult()
            {
                Succeed = isSucceed
            };
        }
           

        public async Task<CreateTaskCommandResult> CreateTaskForMemberCommandHandler(CreateTaskCommand command)
        {
            Domain.DataModels.Task task;

            if (string.IsNullOrEmpty(command.AssignedMemberId))
            {
                task = new Domain.DataModels.Task { Subject = command.Subject };
            }
            else
            {
                var member = await _memberRepository.GetByMemberId(Guid.Parse(command.AssignedMemberId));

                task = new Domain.DataModels.Task { Subject = command.Subject, AssignedMemberId = member.Id };
            }
            

            var persistedTask = await _taskRepository.CreateRecordAsync(task);

            var taskAndMember = await _taskRepository.SelectFirstOrDefaultAsync(u => u.Id == persistedTask.Id, "Member");

            var vm = _mapper.Map<TaskVm>(taskAndMember);

            return new CreateTaskCommandResult()
            {
                Payload = vm
            };
        }

        public async Task<CreateTaskCommandResult> CreateNewTaskCommandHandler(CreateTaskCommand command)
        {
            var task = _mapper.Map<Domain.DataModels.Task>(command);
            
            var persistedTask = await _taskRepository.CreateRecordAsync(task);

            var taskAndMember = await _taskRepository.SelectFirstOrDefaultAsync(u => u.Id == persistedTask.Id, "Member");

            var vm = _mapper.Map<TaskVm>(taskAndMember);

            return new CreateTaskCommandResult()
            {
                Payload = vm
            };
        }


        public async Task<GetAllTaskQueryResult> GetAllTask()
        {
            
            var taskList =  await _taskRepository.ToListAsync("Member");            

            var result = taskList.Select(u => _mapper.Map<TaskVm>(u)).ToList();

            return new GetAllTaskQueryResult
            {
                Payload = result
            };
        }

        public async Task<GetAllTaskQueryResult> GetMemberTasks(Guid memberId)
        {
            var member = await _memberRepository.ByIdAsync(memberId);

            var  taskList = await _taskRepository.ToListAsync("Member", u => u.AssignedMemberId == member.Id);

            var result = taskList.Select(u => _mapper.Map<TaskVm>(u)).ToList();

            return new GetAllTaskQueryResult
            {
                Payload = result
            };
        }



    }
}
