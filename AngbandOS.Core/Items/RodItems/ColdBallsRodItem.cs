namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ColdBallsRodItem : RodItem
    {
        public ColdBallsRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodColdBalls>()) { }
    }
}