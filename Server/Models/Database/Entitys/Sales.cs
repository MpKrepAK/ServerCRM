using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Sales
{
    public long Id { get; set; }
    public DateTime IssueDate { get; set; }
    [ForeignKey("Customer")]
    public long CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    public virtual Product? Product { get; set; }
    [ForeignKey("Address")]
    public long AddressId { get; set; }
    public virtual Address? Address { get; set; }
}