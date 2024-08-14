using Nordax.Bank.Recruitment.Domain.Interfaces.Commands;
using Nordax.Bank.Recruitment.Domain.Interfaces.Repositories;

namespace Nordax.Bank.Recruitment.Logic.Commands;

public class LoanCommands : ILoanCommands
{
  private readonly ILoanRepository _loanRepository;

  public LoanCommands(ILoanRepository loanRepository)
  {
    _loanRepository = loanRepository;
  }

  public async Task<Guid> RegisterLoanAsync(string name, string email, int amount)
  {
    var loanApplicationId = await _loanRepository.RegisterLoanAsync(name, email, amount);
    return loanApplicationId;
  }

}