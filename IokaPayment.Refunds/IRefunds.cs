namespace IokaPayment.Refunds;

public interface IRefunds
{
    Task<Response<IReadOnlyCollection<OrderRefund>>> GetOrderRefundsAsync(string orderId, CancellationToken cancellationToken = default);
    Task<Response<RefundedOrder>> RefundOrderAsync(string orderId, CancellationToken cancellationToken = default);
    Task<Response<OrderRefund>> GetOrderRefundByIdAsync(GetRefund query, CancellationToken cancellationToken = default);
}