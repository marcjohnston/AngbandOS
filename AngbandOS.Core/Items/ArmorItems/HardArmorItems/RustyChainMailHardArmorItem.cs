namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RustyChainMailHardArmorItem : HardArmorItem
    {
        public RustyChainMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HardArmorRustyChainMail>()) { }
    }
}