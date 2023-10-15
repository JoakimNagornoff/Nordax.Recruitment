using Nordax.Bank.Recruitment.Domain.Interfaces;

namespace Nordax.Bank.Recruitment.Configuration;

public class AppConfig : IAppConfig
{

    public string Environment { get; set; } = string.Empty;
}