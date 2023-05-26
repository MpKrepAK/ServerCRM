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
    public string FirstName { get; set; }
    [MaxLength(20)]
    public string LastName { get; set; }
    public List<Sales> Sales { get; set; } = new List<Sales>();
    public decimal Balance { get; set; }
    public int Discount { get; set; }
    public Genders Gender { get; set; }
    [ForeignKey("Card")]
    public long CardId { get; set; }
    public Card Card { get; set; }
}