namespace UavApi.Data;
public class Threat
{
    public int Id { get; set; }
    public int UavId { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
