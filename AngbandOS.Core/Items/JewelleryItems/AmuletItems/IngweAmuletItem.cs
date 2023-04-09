namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IngweAmuletItem : AmuletItem
    {
        public IngweAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletIngwe>()) { }
        public override bool InstaArt => true;
    }
}