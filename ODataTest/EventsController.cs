using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataTest;

public class EventsController : ODataController
{
    private Event _event = new()
    {
        Id = 0,
        Activities = new List<Activity> { new() { Id = 1 }, new() { Id = 2 } }
    };

    [EnableQuery]
    public SingleResult<Event> Get(Guid key)
    {
        return SingleResult.Create(new[] { _event }.AsQueryable());
    }

    [EnableQuery]
    public IQueryable<Activity> Getactivities(Guid key)
    {
        return _event.Activities.AsQueryable();
    }
}