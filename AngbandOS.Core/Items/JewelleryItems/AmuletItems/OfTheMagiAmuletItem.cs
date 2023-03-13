namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OfTheMagiAmuletItem : AmuletItem
    {
        public OfTheMagiAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletOfTheMagi>()) { }
    }
}