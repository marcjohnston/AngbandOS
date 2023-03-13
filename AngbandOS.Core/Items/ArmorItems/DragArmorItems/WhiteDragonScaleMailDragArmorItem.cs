namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WhiteDragonScaleMailDragArmorItem : DragArmorItem
    {
        public WhiteDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorWhiteDragonScaleMail>()) { }
    }
}