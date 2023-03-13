namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LawDragonScaleMailDragArmorItem : DragArmorItem
    {
        public LawDragonScaleMailDragArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DragArmorLawDragonScaleMail>()) { }
    }
}