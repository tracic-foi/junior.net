using AbySalto.Junior.Models.DTOs;

namespace AbySalto.Junior.Services {
    public interface IOrderService {
        Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<List<OrderResponseDto>> GetOrdersAsync(bool sortByTotalDesc = false);
        Task<OrderResponseDto?> GetOrderByIdAsync(int id);
        Task<OrderResponseDto?> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto updateOrderStatusDto);

    }
}
