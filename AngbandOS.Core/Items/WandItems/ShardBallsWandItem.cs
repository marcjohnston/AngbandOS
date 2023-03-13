namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ShardBallsWandItem : WandItem
    {
        public ShardBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandShardBalls>()) { }
    }
}