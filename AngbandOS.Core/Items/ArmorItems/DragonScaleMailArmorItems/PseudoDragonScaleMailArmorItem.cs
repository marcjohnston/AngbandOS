namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PseudoDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public PseudoDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PseudoDragonScaleMailArmorItemFactory>()) { }
    }
}