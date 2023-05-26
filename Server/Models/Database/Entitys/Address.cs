using System.ComponentModel.DataAnnotations;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Address
{
    public long Id { get; set; }
    [MaxLength(20)]
    public string Country { get; set; }
    [MaxLength(20)]
    public string City { get; set; }
    [MaxLength(20)]
    public string Street { get; set; }
    [MaxLength(20)]
    public string Number { get; set; }
}