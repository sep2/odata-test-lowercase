namespace ODataTest;

public class Event
{
    public int Id { get; set; }
    public List<Activity> Activities { get; set; } = new();
}

public class Activity
{
    public int Id { get; set; }
}