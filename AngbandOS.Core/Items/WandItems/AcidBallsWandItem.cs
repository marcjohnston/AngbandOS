namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AcidBallsWandItem : WandItem
    {
        public AcidBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandAcidBalls>()) { }
        public override bool IgnoreAcid => true;
    }
}