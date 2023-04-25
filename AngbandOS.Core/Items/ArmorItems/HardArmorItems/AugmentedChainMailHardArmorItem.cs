namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AugmentedChainMailHardArmorItem : HardArmorItem
    {
        public AugmentedChainMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardArmorAugmentedChainMail>()) { }
    }
}