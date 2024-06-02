using MediatR;

namespace Application.Features.Tasks.Queries.GetMenuCounters
{
    public class GetMenuCountersRequest : IRequest<MenuCounterDto>
    {
    }
}