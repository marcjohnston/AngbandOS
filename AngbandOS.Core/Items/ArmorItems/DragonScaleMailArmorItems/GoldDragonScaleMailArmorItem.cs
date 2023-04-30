namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GoldDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public GoldDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GoldDragonScaleMailArmorItemFactory>()) { }
    }
}