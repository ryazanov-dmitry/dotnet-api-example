using System.ComponentModel.DataAnnotations.Schema;

namespace UavApi.Data;

[Table("uav")]
public class Uav
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("model")]
    public string Model { get; set; } = string.Empty;
}
