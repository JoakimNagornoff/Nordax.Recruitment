using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nordax.Bank.Recruitment.DataAccess.Entities;
using Nordax.Bank.Recruitment.DataAccess.Exceptions;
using Nordax.Bank.Recruitment.Domain.Interfaces.Repositories;
using Nordax.Bank.Recruitment.Domain.Models;

namespace Nordax.Bank.Recruitment.DataAccess.Repositories;

public class LoanRepository : ILoanRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public LoanRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task<Guid> RegisterLoanApplicationAsync(string name, string email, int amount)
  {
    var newLoanApplication = await _applicationDbContext.loans.AddAsync(new LoanApplication(name, email, amount));
    await _applicationDbContext.SaveChangesAsync();

    return newLoanApplication.Entity.id
  }
}