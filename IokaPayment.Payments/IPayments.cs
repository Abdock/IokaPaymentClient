namespace IokaPayment.Payments;

public interface IPayments
{
    Task<Response<PagedResponse<Payment>>> GetPaymentsAsync(PaymentsPaginationQuery query, CancellationToken cancellationToken = default);
    Task<Response<OrderPayment>> CreateCardPaymentAsync(CardPayment cardPayment, CancellationToken cancellationToken = default);
    Task<Response<OrderPayment>> CreateToolPaymentAsync(ToolPayment toolPayment, CancellationToken cancellationToken = default);
    Task<Response<OrderPayment>> GetPaymentByIdAsync(GetPayment query, CancellationToken cancellationToken = default);
}