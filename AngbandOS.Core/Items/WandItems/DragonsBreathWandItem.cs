namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsBreathWandItem : WandItem
    {
        public DragonsBreathWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDragonsBreath>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}