using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Opens
{
    [Key]
    public int OpenId { get; set; }
    public int MeasureId { get; set; }
    public int BakerId { get; set; }
}
