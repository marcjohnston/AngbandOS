namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonHelmArmorItem : HelmArmorItem
    {
        public DragonHelmArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HelmDragonHelm>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}