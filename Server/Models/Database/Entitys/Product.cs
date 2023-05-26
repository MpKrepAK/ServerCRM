using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [ForeignKey("Type")]
    public long TypeId { get; set; }
    public ProductType Type { get; set; }
    public decimal Cost { get; set; }
    public byte[] Image { get; set; }
    [ForeignKey("Manufacturer")]
    public long ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public List<ProductInfo> InfoList { get; set; }
}