using IokaPayment.Accounts.Responses;
using IokaPayment.General.Responses;

namespace IokaPayment.Accounts;

public interface IAccounts
{
    Task<Response<IReadOnlyCollection<AccountResponse>>> GetAccountsAsync(CancellationToken cancellationToken = default);
    Task<Response<AccountResponse>> GetAccountAsync(string accountId, CancellationToken cancellationToken = default);
}