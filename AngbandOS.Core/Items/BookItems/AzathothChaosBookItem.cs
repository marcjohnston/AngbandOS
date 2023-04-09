namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AzathothChaosBookItem : ChaosBookItem
    {
        public AzathothChaosBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ChaosBookTheBookofAzathoth>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}