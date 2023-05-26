using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Server_Side.Models.Database.Entitys;

public class CardItem
{
    public long Id { get; set; }
    public int Count { get; set; }
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public DateTime Date { get; set; }
}