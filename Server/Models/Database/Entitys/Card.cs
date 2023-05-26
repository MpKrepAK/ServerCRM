using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Card
{
    public long Id { get; set; }
    [ForeignKey("Customer")]
    public long CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public List<CardItem> CardItems { get; set; }
}