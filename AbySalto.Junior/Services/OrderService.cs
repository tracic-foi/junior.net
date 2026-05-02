using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models.DTOs;
using AbySalto.Junior.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Services {
    public class OrderService : IOrderService {

        private readonly IApplicationDbContext _db;

        public OrderService(IApplicationDbContext db) {
            _db = db;
        }
        public async Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto dto) {
            var order = new Order {
                CustomerName = dto.CustomerName,
                PaymentType = dto.PaymentType,
                CustomerAddress = dto.CustomerAddress,
                CustomerNumber = dto.CustomerNumber,
                Note = dto.Note,
                Items = dto.Items.Select(i => new OrderItem {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList(),
                Currency = dto.Currency,
                Total = dto.Items.Sum(i => i.Price * i.Quantity)
            };
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return MapToDto(order);
        }

        public async Task<OrderResponseDto?> GetOrderByIdAsync(int id) {
            var order = await _db.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);

            return order is null ? null : MapToDto(order);
        }

        public async Task<List<OrderResponseDto>> GetOrdersAsync(bool sortByTotalDesc = false) {
            var query = _db.Orders
                .Include(o => o.Items)
                .AsQueryable();
            if (sortByTotalDesc)
                query = query.OrderByDescending(o => o.Total);
            var orders = await query.ToListAsync();

            return [.. orders.Select(MapToDto)];  
        }

        public async Task<OrderResponseDto?> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto updateOrderStatusDto) {
            var order = await _db.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order is null)
                return null;
            order.Status = updateOrderStatusDto.Status;
            await _db.SaveChangesAsync();
            return MapToDto(order);
        }
        private static OrderResponseDto MapToDto(Order order) => new() {
            Id = order.Id,
            Status = order.Status,
            CustomerName = order.CustomerName,
            OrderTime = order.OrderTime,
            PaymentType = order.PaymentType,
            CustomerAddress = order.CustomerAddress,
            CustomerNumber = order.CustomerNumber,
            Note = order.Note,
            Items = order.Items.Select(i => new OrderItemResponseDto {
                Id = i.Id,
                Name = i.Name,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList(),
            Total = order.Total,
            Currency = order.Currency
        };
    }
}
