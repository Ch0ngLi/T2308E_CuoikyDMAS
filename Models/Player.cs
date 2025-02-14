namespace BattleGameAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Level { get; set; }
        public List<PlayerAsset> PlayerAssets { get; set; } = new();
    }
}