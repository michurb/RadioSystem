namespace RadioSchedulingSystem.Application.DTO;

public class ShowDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Presenter { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
}