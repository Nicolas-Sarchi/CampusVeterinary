

namespace API.Dtos;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Reason { get; set; }
}
