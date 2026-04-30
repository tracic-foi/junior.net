using AbySalto.Junior.Models.Entities;
using AbySalto.Junior.Models.Enums;

namespace AbySalto.Junior.Models.DTOs {
    public class CreateOrderDto {
        public required string CustomerName { get; set; }
        public PaymentType PaymentType { get; set; }
        public required string CustomerAddress { get; set; }
        public required string CustomerNumber { get; set; }
        public string? Note { get; set; }
        public List<CreateOrderItemDto> Items { get; set; } = new List<CreateOrderItemDto>();
        public required string Currency { get; set; }
    }

    public class CreateOrderItemDto {
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
