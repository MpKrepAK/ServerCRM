using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Product
{
    public long Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }
    [ForeignKey("Type")]
    public long TypeId { get; set; }
    public virtual ProductType? Type { get; set; }
    public decimal Cost { get; set; }
    public byte[]? Image { get; set; }
    [ForeignKey("Manufacturer")]
    public long ManufacturerId { get; set; }
    public virtual Manufacturer? Manufacturer { get; set; }
    public virtual List<ProductInfo>? InfoList { get; set; }
}