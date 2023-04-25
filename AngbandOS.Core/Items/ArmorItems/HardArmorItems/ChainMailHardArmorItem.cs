namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ChainMailHardArmorItem : HardArmorItem
    {
        public ChainMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardArmorChainMail>()) { }
    }
}