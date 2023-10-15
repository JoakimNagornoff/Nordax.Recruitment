using System.ComponentModel.DataAnnotations;

namespace Nordax.Bank.Recruitment.Models.Subscriber;

public record NewSubscriberRequest(
    [Required] string Name,
    [Required] [EmailAddress(ErrorMessage = "Not a valid email")] string Email
);