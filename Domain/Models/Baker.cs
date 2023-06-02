using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Baker
{
    [Key]
    public int BakerId { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string NumberHouse { get; set; }
}
