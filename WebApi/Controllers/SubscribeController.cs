using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Subscribe(string email)
        {
        return Ok();
        }

    [HttpDelete]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        return Ok();
    }
}
