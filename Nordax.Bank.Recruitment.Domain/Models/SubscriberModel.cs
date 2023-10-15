using System;

namespace Nordax.Bank.Recruitment.Domain.Models;

public record SubscriberModel(Guid Id, string Name, string Email, DateTime SignUpDate); 