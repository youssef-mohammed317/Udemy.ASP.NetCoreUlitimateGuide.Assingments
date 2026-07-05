using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Assignment10_BankApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private object _account = new
    {
        accountNumber = 1001,
        accountHolderName = "Example Name",
        currentBalance = 5000
    };
    [HttpGet("/")]
    public IActionResult Index()
    {
        //return new ContentResult
        //{
        //    Content = "Welcome to the Best Bank",
        //    StatusCode = 200,
        //};
        return Ok("Welcome to the Best Bank");
    }
    [HttpGet("/account-details")]
    public IActionResult AccountDetails()
    {
        //return new JsonResult(_account)
        //{
        //    StatusCode = 200,
        //    ContentType = "application/json",
        //};
        return Ok(JsonSerializer.Serialize(_account));
    }
    [HttpGet("/account-statement")]
    public IActionResult AccountStatement()
    {
        HttpContext.Response.StatusCode = 200;
        //return new VirtualFileResult("Section06.pdf", "application/pdf");
        //return new PhysicalFileResult("F:\\Udemy\\Learning\\ASP.NetCore\\Assignments\\Section06_Assignments\\Assignment10_BankApp\\wwwroot\\Section06.pdf", "application/pdf");

        //return File("Section06.pdf", "application/pdf");
        //return PhysicalFile("F:\\Udemy\\Learning\\ASP.NetCore\\Assignments\\Section06_Assignments\\Assignment10_BankApp\\wwwroot\\Section06.pdf", "application/pdf");
        using var reader = new StreamReader("F:\\Udemy\\Learning\\ASP.NetCore\\Assignments\\Section06_Assignments\\Assignment10_BankApp\\wwwroot\\TextFile.txt");
        var text = reader.ReadToEnd();
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        return File(bytes, "text/plain");
    }
    [HttpGet("/get-current-balance/{accountNumber:int?}")]
    public IActionResult GetCurrentBalance([FromRoute] int? accountNumber = null)
    {
        if (accountNumber == null)
        {
            return NotFound("Account Number should be supplied");
        }

        if (accountNumber == 1001)
        {
            return Ok(5000);
        }
        else
        {
            return BadRequest("Account Number should be 1001");
        }
    }
}
