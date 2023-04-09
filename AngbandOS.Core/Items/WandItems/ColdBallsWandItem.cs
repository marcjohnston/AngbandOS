namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ColdBallsWandItem : WandItem
    {
        public ColdBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandColdBalls>()) { }
        public override bool IgnoreCold => true;
    }
}