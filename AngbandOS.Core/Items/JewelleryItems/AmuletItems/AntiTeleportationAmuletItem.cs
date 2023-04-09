namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AntiTeleportationAmuletItem : AmuletItem
    {
        public AntiTeleportationAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletAntiTeleportation>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool NoTele => true;
    }
}