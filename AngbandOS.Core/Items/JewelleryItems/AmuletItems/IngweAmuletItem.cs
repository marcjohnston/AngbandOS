namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IngweAmuletItem : AmuletItem
    {
        public IngweAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AmuletIngwe>()) { }
    }
}