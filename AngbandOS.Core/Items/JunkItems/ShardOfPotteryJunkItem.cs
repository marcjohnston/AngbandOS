namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ShardOfPotteryJunkItem : JunkItem
    {
        public ShardOfPotteryJunkItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<JunkShardOfPottery>()) { }
    }
}