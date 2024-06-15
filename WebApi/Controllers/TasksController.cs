using Application.Features.Tasks.Commands.CompleteTask;
using Application.Features.Tasks.Commands.CreateTask;
using Application.Features.Tasks.Commands.DeleteTask;
using Application.Features.Tasks.Commands.UpdateTask;
using Application.Features.Tasks.Dtos;
using Application.Features.Tasks.Queries.GetCompletedTasks;
using Application.Features.Tasks.Queries.GetMenuCounters;
using Application.Features.Tasks.Queries.GetOverdueTasks;
using Application.Features.Tasks.Queries.GetTasksByCategory;
using Application.Features.Tasks.Queries.GetUpcomingTasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator mediator;

        public TasksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("category/{categoryId}")]
        [Authorize]
        public async Task<IActionResult> GetByCategory([FromRoute] int categoryId)
        {
            return Ok(await mediator.Send(new GetTasksByCategoryRequest { CategoryId = categoryId }));
        }

        [HttpGet("upcoming")]
        [Authorize]
        public async Task<IActionResult> GetUpcoming([FromQuery] bool onlyToday = false)
        {
            var timezone = Request.Headers["User-Timezone"].First();
            return Ok(await mediator.Send(new GetUpcomingTasksRequest { OnlyToday = onlyToday, Timezone = timezone }));
        }

        [HttpGet("overdue")]
        [Authorize]
        public async Task<IActionResult> GetOverdue()
        {
            var timezone = Request.Headers["User-Timezone"].First();
            return Ok(await mediator.Send(new GetOverdueTasksRequest { Timezone = timezone }));
        }

        [HttpGet("completed")]
        [Authorize]
        public async Task<IActionResult> GetCompleted()
        {
            return Ok(await mediator.Send(new GetCompletedTasksRequest()));
        }

        [HttpGet("get-menu-counters")]
        [Authorize]
        public async Task<IActionResult> GetMenuCounters()
        {
            var timezone = Request.Headers["User-Timezone"].First();
            return Ok(await mediator.Send(new GetMenuCountersRequest { Timezone = timezone }));
        }

        [HttpPut("complete/{id}")]
        [Authorize]
        public async Task<IActionResult> Complete([FromRoute] int id)
        {
            return Ok(await mediator.Send(new CompleteTaskRequest { Id = id }));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskRequestDto request)
        {
            return Ok(await mediator.Send(new UpdateTaskRequest
            {
                Id = id,
                Name = request.Name,
                Deadline = request.Deadline,
                CategoryId = request.CategoryId
            }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTask(int id)
        {
            return Ok(await mediator.Send(new DeleteTaskRequest { Id = id }));
        }
    }
}