namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CharismaAmuletItem : AmuletItem
    {
        public CharismaAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletCharisma>()) { }
    }
}