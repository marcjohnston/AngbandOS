namespace AngbandOS.Core.Items
{
    [Serializable]
    internal class AcidBallsRodItem : RodItem
    {
        public AcidBallsRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodAcidBalls>()) { }
    }
}