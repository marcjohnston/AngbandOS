namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GreenDragonScaleMailDragArmorItem : DragArmorItem
    {
        public GreenDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorGreenDragonScaleMail>()) { }
    }
}