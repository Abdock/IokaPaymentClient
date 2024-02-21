using IokaPayment.General.Models;
using IokaPayment.General.Responses;

namespace IokaPayment.Accounts;

public interface IAccounts
{
    Task<Response<IReadOnlyCollection<Account>>> GetAccountsAsync(CancellationToken cancellationToken = default);
    Task<Response<Account>> GetAccountAsync(string accountId, CancellationToken cancellationToken = default);
}