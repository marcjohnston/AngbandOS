namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightningBallsWandItem : WandItem
    {
        public LightningBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandLightningBalls>()) { }
        public override bool IgnoreElec => true;
    }
}