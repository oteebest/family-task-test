using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstractions.Services;
using Domain.Commands;
using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(CreateTaskCommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _taskService.CreateTaskForMemberCommandHandler(command);

            return Ok(result);
        }

        [HttpGet("member/{memberId}")]
        [ProducesResponseType(typeof(List<TaskVm>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid memberId)
        {           

            var result = await _taskService.GetMemberTasks(memberId);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TaskVm>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {            

            var result = await _taskService.GetAllTask();

            return Ok(result);
        }


        [HttpPost("{id}/toggleActiveStatus")]
        [ProducesResponseType(typeof(ToggleTaskActiveStatusResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> ToggleActiveStatus(string id)
        {            
            
            var result = await _taskService.ToggleActiveStatus(Guid.Parse(id));

            return Ok(result);
        }


        [HttpPost("{id}/assign/{memberId}")]
        [ProducesResponseType(typeof(AssignTaskCommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> AssignTaskToMember(Guid id,Guid memberId)
        {
         
            var result = await _taskService.AssignTaskToMember(id,memberId);

            return Ok(result);
        }
    
    
    }
}
