namespace RadioSchedulingSystem.Application.DTO;

public class CreateShowDto
{
    public required string Title { get; set; }
    public required string Presenter { get; set; }
    public DateTime StartTime { get; set; }
    public int DurationMinutes { get; set; }
}