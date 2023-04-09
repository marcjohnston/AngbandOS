namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsBreathWandItem : WandItem
    {
        public DragonsBreathWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDragonsBreath>()) { }
    }
}