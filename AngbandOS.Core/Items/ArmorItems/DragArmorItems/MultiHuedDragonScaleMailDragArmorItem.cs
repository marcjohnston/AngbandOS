namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MultiHuedDragonScaleMailDragArmorItem : DragArmorItem
    {
        public MultiHuedDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorMultiHuedDragonScaleMail>()) { }
    }
}