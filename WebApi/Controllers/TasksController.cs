using Application.Features.Tasks.Commands.CreateTask;
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
        public async Task<IActionResult> GetUpcoming()
        {
            return Ok(await mediator.Send(new GetUpcomingTasksRequest()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            return Ok(await mediator.Send(request));
        }
    }
}