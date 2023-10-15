using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nordax.Bank.Recruitment.DataAccess.Exceptions;
using Nordax.Bank.Recruitment.Domain.Interfaces.Commands;
using Nordax.Bank.Recruitment.Domain.Interfaces.Queries;
using Nordax.Bank.Recruitment.Models.Subscriber;

namespace Nordax.Bank.Recruitment.Controllers;

[ApiController]
[Route("api/subscriber")]
public class SubscribersController : ControllerBase
{
    private readonly ISubscriptionCommands _subscriptionCommands;
    private readonly ISubscriptionQueries _subscriptionQueries;

    public SubscribersController(ISubscriptionCommands subscriptionCommands, ISubscriptionQueries subscriptionQueries)
    {
        _subscriptionCommands = subscriptionCommands;
        _subscriptionQueries = subscriptionQueries;
    }

    [HttpPost]
    public async Task<IActionResult> AddSubscriber([Required] [FromBody] NewSubscriberRequest request)
    {
        try
        {
            var subscriberId = await _subscriptionCommands.RegisterSubscriptionAsync(request.Name, request.Email);
            return Ok(new NewSubscriberResponse(subscriberId));
        }
        catch (Exception e)
        {
            if (e is EmailAlreadyRegisteredException) return Conflict($"Email {request.Email} already registered");
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{subscriberId:Guid}")]
    public async Task<IActionResult> DeleteSubscriber([Required] [FromRoute] Guid subscriberId)
    {
        try
        {
            await _subscriptionCommands.DeleteSubscriberAsync(subscriberId);
            return Ok();
        }
        catch (Exception e)
        {
            if (e is UserNotFoundException) return NotFound("No user found with that id");
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{subscriberId:Guid}")]
    [ProducesResponseType(typeof(SubscriberResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSubscriber([Required] [FromRoute] Guid subscriberId)
    {
        try
        {
            var subscriber = await _subscriptionQueries.GetSubscriberAsync(subscriberId);
            return Ok(new SubscriberResponse(subscriber.Name, subscriber.Id));
        }
        catch (Exception e)
        {
            if (e is UserNotFoundException) return NotFound("No user found with that id");
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}