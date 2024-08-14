
using System.Threading.Tasks;
using System;
using System.IO;

namespace Nordax.Bank.Recruitment.Domain.Interfaces.Commands;

public interface ILoanCommands
{
    Task<Guid> RegisterLoanAsync(string name, string email, int amount);
}


