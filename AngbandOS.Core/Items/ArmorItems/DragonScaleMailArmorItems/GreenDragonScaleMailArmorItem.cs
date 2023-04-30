namespace AngbandOS.Core.Items
{
[Serializable]
    internal class GreenDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public GreenDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<GreenDragonScaleMailArmorItemFactory>()) { }
    }
}