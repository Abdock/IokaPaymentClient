using IokaPayment.Orders.Requests;
using IokaPayment.Orders.Responses;

namespace IokaPayment.Orders;

public interface IOrders
{
    Task<Response<CreatedOrder>> CreateOrderAsync(OrderData request, CancellationToken cancellationToken = default);
    Task<Response<PagedResponse<Order>>> GetOrdersAsync(OrdersPaginationQuery request, CancellationToken cancellationToken = default);
    Task<Response<Order>> GetOrderByIdAsync(string orderId, CancellationToken cancellationToken = default);
    Task<Response<Order>> UpdateOrderByIdAsync(UpdateOrderRequest updateRequest, CancellationToken cancellationToken = default);
    Task<Response<ModifiedOrder>> CaptureOrderAsync(CaptureOrderRequest captureRequest, CancellationToken cancellationToken = default);
    Task<Response<ModifiedOrder>> CancelOrderAsync(CancelOrderRequest cancelRequest, CancellationToken cancellationToken = default);
}