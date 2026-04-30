using AbySalto.Junior.Models.Enums;

namespace AbySalto.Junior.Models.DTOs {
    public class OrderResponseDto {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public required string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public PaymentType PaymentType { get; set; }
        public required string CustomerAddress { get; set; }
        public required string CustomerNumber { get; set; }
        public string? Note { get; set; }
        public List<OrderItemResponseDto> Items { get; set; } = new List<OrderItemResponseDto>();
        public decimal Total { get; set; }
        public required string Currency { get; set; }
    }
    public class OrderItemResponseDto {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

