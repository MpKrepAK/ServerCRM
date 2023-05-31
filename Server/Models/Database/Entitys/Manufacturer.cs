using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Manufacturer
{
    public long Id { get; set; }
    public List<Product> Products { get; set; }
    [ForeignKey("Address")]
    public long AddressId { get; set; }
    public Address Address { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
}