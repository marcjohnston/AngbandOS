namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WonderWandItem : WandItem
    {
        public WonderWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandWonder>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}