using BattleGameAPI.Data;
using BattleGameAPI.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly BattleGameDbContext _context;

    public PlayerController(BattleGameDbContext context)
    {
        _context = context;
    }

    [HttpPost("registerplayer")]
    public async Task<IActionResult> RegisterPlayer(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return Ok(player);
    }
}