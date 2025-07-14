namespace RadioSchedulingSystem.Application.DTO;

public class ShowReportDto
{
    public DateTime Date { get; set; }
    public int TotalShows { get; set; }
    public int TotalDuration { get; set; }
    public IEnumerable<ShowDto> Shows { get; set; } = new List<ShowDto>();
}