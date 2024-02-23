namespace IokaPayment.Payments;

public interface IPayments
{
    Task<Response<PagedResponse<Payment>>> GetPaymentsAsync(PaymentsPaginationQuery query, CancellationToken cancellationToken = default);
    Task<Response<PaymentInformation>> CreateCardPaymentAsync(CardPaymentByNewCard cardPayment, CancellationToken cancellationToken = default);
    Task<Response<PaymentInformation>> CreateCardPaymentAsync(CardPaymentBySavedCard cardPayment, CancellationToken cancellationToken = default);
    Task<Response<PaymentInformation>> CreateToolPaymentAsync(ToolPayment toolPayment, CancellationToken cancellationToken = default);
    Task<Response<PaymentInformation>> GetPaymentByIdAsync(GetPayment query, CancellationToken cancellationToken = default);
}