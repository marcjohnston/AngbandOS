namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GoldDragonScaleMailDragArmorItem : DragArmorItem
    {
        public GoldDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorGoldDragonScaleMail>()) { }
    }
}