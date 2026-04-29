using AbySalto.Junior.Models.Enums;

namespace AbySalto.Junior.Models.Entities; 
public class Order {
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public required string CustomerName { get; set; }
    public DateTime OrderTime { get; set; } = DateTime.UtcNow;
    public required string PaymentType { get; set; }
    public required string CustomerAddress { get; set; }
    public required string CustomerNumber { get; set; }
    public string? Note { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public decimal Total { get; set; }
    public required string Currency {  get; set; }
}
