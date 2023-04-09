namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ChaosScrollItem : ScrollItem
    {
        public ChaosScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollChaos>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}