using Application.Features.Tasks.Commands.CompleteTask;
using Application.Features.Tasks.Commands.CreateTask;
using Application.Features.Tasks.Commands.DeleteTask;
using Application.Features.Tasks.Queries.GetCompletedTasks;
using Application.Features.Tasks.Queries.GetMenuCounters;
using Application.Features.Tasks.Queries.GetOverdueTasks;
using Application.Features.Tasks.Queries.GetTasksByCategory;
using Application.Features.Tasks.Queries.GetUpcomingTasks;
using MediatR;
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
        public async Task<IActionResult> GetByCategory([FromRoute] int categoryId)
        {
            return Ok(await mediator.Send(new GetTasksByCategoryRequest { CategoryId = categoryId }));
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcoming([FromQuery] bool onlyToday = false)
        {
            var timezone = Request.Headers["User-Timezone"].First();
            return Ok(await mediator.Send(new GetUpcomingTasksRequest { OnlyToday = onlyToday, Timezone = timezone }));
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdue()
        {
            var timezone = Request.Headers["User-Timezone"].First();
            return Ok(await mediator.Send(new GetOverdueTasksRequest { Timezone = timezone }));
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompleted()
        {
            return Ok(await mediator.Send(new GetCompletedTasksRequest()));
        }

        [HttpGet("get-menu-counters")]
        public async Task<IActionResult> GetMenuCounters()
        {
            var timezone = Request.Headers["User-Timezone"].First();
            return Ok(await mediator.Send(new GetMenuCountersRequest { Timezone = timezone }));
        }

        [HttpPut("complete/{id}")]
        public async Task<IActionResult> Complete([FromRoute] int id)
        {
            return Ok(await mediator.Send(new CompleteTaskRequest { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            return Ok(await mediator.Send(new DeleteTaskRequest { Id = id }));
        }
    }
}