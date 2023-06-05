using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Supplies
{
    public long Id { get; set; }
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public int Count { get; set; }
    public DateTime Date { get; set; }
    [ForeignKey("Employee")]
    public long EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
}