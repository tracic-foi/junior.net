namespace AbySalto.Junior.Models.Entities; 
public class OrderItem {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public required string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
