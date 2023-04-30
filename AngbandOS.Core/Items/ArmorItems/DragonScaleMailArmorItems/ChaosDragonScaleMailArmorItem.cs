namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ChaosDragonScaleMailArmorItem : DragonScaleMailArmorItem
    {
        public ChaosDragonScaleMailArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ChaosDragonScaleMailArmorItemFactory>()) { }
    }
}