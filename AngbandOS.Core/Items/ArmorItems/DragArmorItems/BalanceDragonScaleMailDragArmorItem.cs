namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BalanceDragonScaleMailDragArmorItem : DragArmorItem
    {
        public BalanceDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorBalanceDragonScaleMail>()) { }
    }
}