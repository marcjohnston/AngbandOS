namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ChaosDragonScaleMailDragArmorItem : DragArmorItem
    {
        public ChaosDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorChaosDragonScaleMail>()) { }
    }
}