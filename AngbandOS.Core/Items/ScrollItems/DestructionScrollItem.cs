namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DestructionScrollItem : ScrollItem
    {
        public DestructionScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollDestruction>()) { }
    }
}