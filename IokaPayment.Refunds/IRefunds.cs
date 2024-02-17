﻿using IokaPayment.General.Responses;
using IokaPayment.Refunds.Requests;
using IokaPayment.Refunds.Responses;

namespace IokaPayment.Refunds;

public interface IRefunds
{
    Task<Response<IReadOnlyCollection<OrderRefund>>> GetOrderRefundsAsync(string orderId, CancellationToken cancellationToken = default);
    Task<Response<RefundedOrder>> RefundOrderAsync(string orderId, CancellationToken cancellationToken = default);
    Task<Response<OrderRefund>> GetOrderRefundByIdAsync(GetRefund query, CancellationToken cancellationToken = default);
}