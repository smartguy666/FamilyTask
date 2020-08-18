using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstractions.Services;
using Domain.Commands;
using Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

       

        [HttpPost]
        [ProducesResponseType(typeof(CreateMemberTasksCommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateMemberTaskCommand command)
        {
            //return Ok();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _tasksService.CreateMemberTaskCommandHandler(command);

            return Created($"/api/members/{result.Payload.Id}", result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetAllMemberTasksQueryResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _tasksService.GetAllMemberTasksQueryHandler();


            return Ok(result.Payload);
        }
        [HttpGet("DeleteTask")]
        [ProducesResponseType(typeof(GetAllMemberTasksQueryResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTask(string Id)
        {

            Guid GId = new Guid(Id);
            var result = await _tasksService.DeleteTaskQueryHandler(GId);


            return Ok(result);
        }
    }

   

   
}
