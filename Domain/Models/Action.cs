using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Action
{
    [Key]
    public int ActionId { get; set; }
    public string Description { get; set; }

}
