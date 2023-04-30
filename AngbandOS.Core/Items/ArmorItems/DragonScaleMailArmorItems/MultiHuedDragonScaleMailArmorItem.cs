namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MultiHuedDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public MultiHuedDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<MultiHuedDragonScaleMailArmorItemFactory>()) { }
    }
}