namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PseudoDragonScaleMailDragArmorItem : DragArmorItem
    {
        public PseudoDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorPseudoDragonScaleMail>()) { }
    }
}