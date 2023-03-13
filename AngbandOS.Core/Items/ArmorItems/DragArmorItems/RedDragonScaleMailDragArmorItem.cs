namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RedDragonScaleMailDragArmorItem : DragArmorItem
    {
        public RedDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorRedDragonScaleMail>()) { }
    }
}