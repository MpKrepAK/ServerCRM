using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Server_Side.Models.Database.Entitys.Enums;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Customer
{
    public long Id { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(20)]
    public string Password { get; set; }
    [MaxLength(20)]
    public string Nickname { get; set; }
    public virtual List<Sales>? Sales { get; set; } = new List<Sales>();
    public int Discount { get; set; }
    public Genders Gender { get; set; }
    public Roles Role { get; set; }
    public DateTime DateOfRegistration { get; set; }
    // [ForeignKey("Card")]
    // public long CardId { get; set; }
    // public Card Card { get; set; }
}