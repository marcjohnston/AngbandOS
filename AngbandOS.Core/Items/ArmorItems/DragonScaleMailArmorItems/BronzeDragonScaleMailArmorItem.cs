namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BronzeDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public BronzeDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BronzeDragonScaleMailArmorItemFactory>()) { }
    }
}