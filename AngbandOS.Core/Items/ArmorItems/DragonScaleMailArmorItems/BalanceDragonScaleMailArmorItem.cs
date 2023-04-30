namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BalanceDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BalanceDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BalanceDragonScaleMailArmorItemFactory>()) { }
    }
}