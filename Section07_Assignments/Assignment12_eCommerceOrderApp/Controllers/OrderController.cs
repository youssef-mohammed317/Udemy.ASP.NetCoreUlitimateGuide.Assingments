using Assignment12_eCommerceOrderApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment12_eCommerceOrderApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpPost("/order")]
    public IActionResult Index(Order order)
    {
        // not required
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        int orderNo = Random.Shared.Next(1, int.MaxValue);
        order.OrderNo = orderNo;

        return Ok(orderNo);
    }

}
