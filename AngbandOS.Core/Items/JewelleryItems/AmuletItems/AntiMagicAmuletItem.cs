namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiMagicAmuletItem : AmuletItem
    {
        public AntiMagicAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletAntiMagic>()) { }
    }
}