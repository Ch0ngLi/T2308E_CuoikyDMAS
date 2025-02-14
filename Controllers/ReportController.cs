using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BattleGameAPI.Data;
using BattleGameAPI.Models;

namespace BattleGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly BattleGameDbContext _context;

        public ReportController(BattleGameDbContext context)
        {
            _context = context;
        }

        [HttpGet("getassetsbyplayer")]
        public async Task<IActionResult> GetAssetsByPlayer()
        {
            var report = await _context.PlayerAssets
                .Include(pa => pa.Player)
                .Include(pa => pa.Asset)
                .Select(pa => new
                {
                    PlayerName = pa.Player.PlayerName,
                    Level = pa.Player.Level,
                    Age = pa.Player.Age,
                    AssetName = pa.Asset.AssetName
                })
                .ToListAsync();

            return Ok(report);
        }
    }
}