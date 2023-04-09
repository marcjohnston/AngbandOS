namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ShardBallsWandItem : WandItem
    {
        public ShardBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandShardBalls>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}