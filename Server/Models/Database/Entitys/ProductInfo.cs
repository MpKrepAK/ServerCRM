using System.ComponentModel.DataAnnotations;

namespace CRM_Server_Side.Models.Database.Entitys;

public class ProductInfo
{
    public long Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Value { get; set; }
}