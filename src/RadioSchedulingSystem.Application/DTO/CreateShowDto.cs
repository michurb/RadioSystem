namespace RadioSchedulingSystem.Application.DTO;

public class CreateShowDto
{
    public string Title { get; set; }
    public string Presenter { get; set; }
    public DateTime StartTime { get; set; }
    public int DurationMinutes { get; set; }
}