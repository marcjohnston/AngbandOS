namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlueDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BlueDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBlueDragonScaleMail>()) { }
    }
}