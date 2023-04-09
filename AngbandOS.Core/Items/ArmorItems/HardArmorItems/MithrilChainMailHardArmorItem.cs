namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MithrilChainMailHardArmorItem : HardArmorItem
    {
        public MithrilChainMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HardArmorMithrilChainMail>()) { }
        public override bool IgnoreAcid => true;
    }
}