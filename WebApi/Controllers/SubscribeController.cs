using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController(ApiContexts contex) : ControllerBase
{
    private readonly ApiContexts _contex = contex;

    [HttpPost]
    public async Task<IActionResult> Subscribe(string email)
        {
            if(ModelState.IsValid) 
            {
            if(await _contex.Subscribers.AnyAsync(x => x.Email == email))
                return Conflict();

            _contex.Add(new SubscribersEntity { Email = email });
            await _contex.SaveChangesAsync();
            return Ok(); 
            }

            return BadRequest();
        }

    [HttpDelete]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        if (ModelState.IsValid)
        {
            var subscriberEntity = await _contex.Subscribers.FirstOrDefaultAsync (x => x.Email == email);
            if (subscriberEntity == null)
                return NotFound();

            _contex.Remove(subscriberEntity);
            await _contex.SaveChangesAsync();
            return Ok();
        }


        return BadRequest();
    }
}
