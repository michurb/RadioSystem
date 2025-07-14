namespace RadioSchedulingSystem.Domain.Entities;

public class Show
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Presenter { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
}