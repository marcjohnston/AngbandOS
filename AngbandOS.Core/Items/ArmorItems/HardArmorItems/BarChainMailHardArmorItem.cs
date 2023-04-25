namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BarChainMailHardArmorItem : HardArmorItem
    {
        public BarChainMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardArmorBarChainMail>()) { }
    }
}