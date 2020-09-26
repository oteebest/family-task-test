using Domain.Commands;
using Domain.Queries;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Abstractions;
using WebClient.Exentions;

namespace WebClient.Services
{
    public class TaskDataService : ITaskDataService
    {
        private HttpClient _httpClient;
        public TaskDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task ToggleActiveStatus(Guid id)
        {
            var response = await _httpClient.PostAsync($"tasks/{id}/toggleActiveStatus",null);
        }

        public async Task<TaskModel> CreateTask(NewTask task)
        {

            var result = await _httpClient.PostJsonAsync<CreateTaskCommandResult>("tasks", task);

            return result.Payload.Map();
        }

        public async Task AssignTaskToMember(string taskId,string memberId)
        {
            
            var result = await _httpClient.PostJsonAsync<AssignTaskCommandResult>($"tasks/{taskId}/assign/{memberId}", null);
        }

        public async Task<TaskModel[]> GetAllTask()
        {
            var result = await _httpClient.GetJsonAsync<GetAllTaskQueryResult>("tasks");

            return result.Payload.Select(u => u.Map()).ToArray();
        }

        public async Task<TaskModel[]> GetMemberTask(Guid memberId)
        {
            var result = await _httpClient.GetJsonAsync<GetAllTaskQueryResult>($"tasks/member/{memberId}");

            return result.Payload.Select(u => u.Map()).ToArray();
        }
    }
}
