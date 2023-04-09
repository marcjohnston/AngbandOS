namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MithrilPlateMailHardArmorItem : HardArmorItem
    {
        public MithrilPlateMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HardArmorMithrilPlateMail>()) { }
        public override bool IgnoreAcid => true;
    }
}