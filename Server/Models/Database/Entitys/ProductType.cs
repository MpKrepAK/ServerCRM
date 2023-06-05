namespace CRM_Server_Side.Models.Database.Entitys;

public class ProductType
{
    public long Id { get; set; }
    public string Name { get; set; }
    public virtual List<Product>? Products { get; set; }
}