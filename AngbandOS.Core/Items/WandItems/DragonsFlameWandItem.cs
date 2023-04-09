namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsFlameWandItem : WandItem
    {
        public DragonsFlameWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDragonsFlame>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}