namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlackDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BlackDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBlackDragonScaleMail>()) { }
    }
}