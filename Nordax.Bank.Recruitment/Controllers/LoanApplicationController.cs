using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nordax.Bank.Recruitment.Models.LoanApplication;

namespace Nordax.Bank.Recruitment.Controllers;

[ApiController]
[Route("api/loan-application")]
public class LoanApplicationController : ControllerBase
{
    public LoanApplicationController()
    {
    }

    [HttpPost("attachment")]
    [ProducesResponseType(typeof(FileResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        //TODO: Store file
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RegisterLoanApplication([Required] [FromBody] RegisterLoanApplicationRequest request)
    {
        //TODO: Store Loan Application
        return Ok();
    }

    [HttpGet("{fileId:Guid}")]
    [ProducesResponseType(typeof(LoanApplicationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLoanApplication([FromRoute] Guid fileId)
    {
        //TODO: Get Loan Application
        return Ok();
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<LoanApplicationResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLoanApplications()
    {
        //TODO: Get Loan Applications
        return Ok();
    }
}