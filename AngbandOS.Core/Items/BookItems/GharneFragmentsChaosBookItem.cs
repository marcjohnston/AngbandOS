namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GharneFragmentsChaosBookItem : ChaosBookItem
    {
        public GharneFragmentsChaosBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChaosBookGharneFragments>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}