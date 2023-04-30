namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RedDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public RedDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RedDragonScaleMailArmorItemFactory>()) { }
    }
}