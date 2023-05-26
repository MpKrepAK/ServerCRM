using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Server_Side.Models.Database.Entitys;

public class VisitedProductsByCustomer
{
    public long Id { get; set; }
    [ForeignKey("Customer")]
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public DateTime Date { get; set; }

    public VisitedProductsByCustomer()
    {
        
    }
    public VisitedProductsByCustomer(Product product, Customer customer)
    {
        Customer = customer;
        Product = product;
        Date = DateTime.Now;
    }
}