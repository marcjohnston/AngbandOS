namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DoubleChainMailHardArmorItem : HardArmorItem
    {
        public DoubleChainMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HardArmorDoubleChainMail>()) { }
    }
}