namespace Application.Features.Tasks.Queries.GetMenuCounters
{
    public class MenuCounterDto
    {
        public int Upcoming { get; set; }
        public int Today { get; set; }
        public int Overdue { get; set; }
        public int Completed { get; set; }
    }
}