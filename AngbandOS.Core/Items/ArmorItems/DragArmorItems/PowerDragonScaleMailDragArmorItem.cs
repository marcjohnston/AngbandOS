namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PowerDragonScaleMailDragArmorItem : DragArmorItem
    {
        public PowerDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorPowerDragonScaleMail>()) { }
    }
}