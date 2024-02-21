using System.Net;
using IokaPayment.Cards.Requests;
using IokaPayment.Cards.Responses;
using IokaPayment.General.Responses;

namespace IokaPayment.Cards;

public interface ICards
{
    Task<Response<IReadOnlyCollection<CustomerCard>>> GetCustomerCardsAsync(string customerId, CancellationToken cancellationToken = default);
    Task<Response<CustomerCard>> GetCustomerCardByIdAsync(GetCard query, CancellationToken cancellationToken = default);
    Task<Response<CustomerCard>> CreateCustomerCardAsync(CreateAndBindCardRequest query, CancellationToken cancellationToken = default);
    Task<Response<HttpStatusCode>> DeleteCustomerCardByIdAsync(GetCard query, CancellationToken cancellationToken = default);
}