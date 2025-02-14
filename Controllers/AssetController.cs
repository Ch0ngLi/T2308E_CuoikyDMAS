using BattleGameAPI.Data;
using BattleGameAPI.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AssetController : ControllerBase
{
    private readonly BattleGameDbContext _context;

    public AssetController(BattleGameDbContext context)
    {
        _context = context;
    }

    [HttpPost("createasset")]
    public async Task<IActionResult> CreateAsset(Asset asset)
    {
        _context.Assets.Add(asset);
        await _context.SaveChangesAsync();
        return Ok(asset);
    }
}