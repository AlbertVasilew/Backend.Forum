using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.Queries.GetMenuCounters
{
    public class GetMenuCountersRequest : IRequest<MenuCounterDto>
    {
        public string Timezone { get; set; }
    }
}