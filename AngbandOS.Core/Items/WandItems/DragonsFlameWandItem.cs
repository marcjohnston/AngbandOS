namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsFlameWandItem : WandItem
    {
        public DragonsFlameWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDragonsFlame>()) { }
    }
}