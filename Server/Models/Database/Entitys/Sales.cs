using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Sales
{
    public long Id { get; set; }
    public DateTime IssueDate { get; set; }
    [ForeignKey("Customer")]
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    public Product Product { get; set; }
    [ForeignKey("Address")]
    public long AddressId { get; set; }
    public Address Address { get; set; }
}