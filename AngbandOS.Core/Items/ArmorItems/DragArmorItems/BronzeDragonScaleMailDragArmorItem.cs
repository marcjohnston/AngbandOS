namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BronzeDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BronzeDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBronzeDragonScaleMail>()) { }
    }
}