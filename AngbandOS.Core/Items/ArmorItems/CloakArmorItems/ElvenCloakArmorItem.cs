namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ElvenCloakArmorItem : CloakArmorItem
    {
        public ElvenCloakArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<CloakElven>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool Search => true;
        public override bool Stealth => true;
    }
}