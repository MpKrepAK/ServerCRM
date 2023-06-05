using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Manufacturer
{
    public long Id { get; set; }
    public virtual List<Product>? Products { get; set; }
    [ForeignKey("Address")]
    public long AddressId { get; set; }
    public virtual Address? Address { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
}