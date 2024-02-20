using IokaPayment.General.Models;
using IokaPayment.Orders.Requests;
using IokaPayment.Orders.Responses;

namespace IokaPayment.Orders;

public interface IOrders
{
    Task<Response<CreatedOrder>> CreateOrderAsync(OrderData request, CancellationToken cancellationToken = default);
    Task<Response<PagedResponse<ShortOrder>>> GetOrdersAsync(OrdersPaginationQuery request, CancellationToken cancellationToken = default);
    Task<Response<Order>> GetOrderByIdAsync(string orderId, CancellationToken cancellationToken = default);
    Task<Response<Order>> UpdateOrderByIdAsync(UpdateOrderRequest updateRequest, CancellationToken cancellationToken = default);
    Task<Response<OrderPayment>> CaptureOrderAsync(CaptureOrderRequest captureRequest, CancellationToken cancellationToken = default);
    Task<Response<OrderPayment>> CancelOrderAsync(CancelOrderRequest cancelRequest, CancellationToken cancellationToken = default);
}